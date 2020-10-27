using Git.Data;
using Git.ViewModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(AddRepositoryInputModel repositoryInputModel, string userId)
        {
            var dbRepository = new Repository 
            { 
                Name = repositoryInputModel.Name,
                OwnerId = userId,
                CreatedOn = DateTime.Now,
                IsPublic = repositoryInputModel.RepositoryType == "Public" ? true : false,
            };

            this.db.Repositories.Add(dbRepository);
            this.db.SaveChanges();

            return dbRepository?.Id;
        }

        public IEnumerable<PublicRepositoriesViewModel> GetAllPublicRepositories()
        {
            var dbPublicRepositories = this.db.Repositories
                .Where(x=>x.IsPublic)
                .Select(x => new PublicRepositoriesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner.Username,
                CommitsCount = x.Commits.Count(),
                CreatedOn = x.CreatedOn,
            }).ToList();
            return dbPublicRepositories;
        }

        public string GetNameById(string id)
        {
            return this.db.Repositories.FirstOrDefault(x => x.Id == id)?.Name;
        }
    }
}
