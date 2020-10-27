using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsServices : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Create(string commit, string userId, string repoId)
        {
            var dBCommit = new Commit
            {
                Description = commit,
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                RepositoryId = repoId,
            };
            this.db.Commits.Add(dBCommit);
            this.db.SaveChanges();
            return dBCommit?.Id;
        }

        public IEnumerable<AllCommitsVIewModel> GetAll(string userId)
        {
            var commits = this.db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new AllCommitsVIewModel()
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Repository = x.Repository.Name,
                    Description = x.Description,
                }).ToList();
            return commits;
        }

        public bool IsUserCreator(string userId, string commitId)
        {
            var userCommit = this.db.Commits.FirstOrDefault(x => x.Id == commitId);

            if (userCommit == null || userCommit.CreatorId != userId)
            {
                return false;
            }
            return true;
        }

        public bool Delete(string commitId)
        {
            var dbCommit = this.db.Commits.FirstOrDefault(x => x.Id == commitId);
            if (dbCommit == null)
            {
                return false;
            }

            this.db.Commits.Remove(dbCommit);
            this.db.SaveChanges();
            return true;
        }

    }
}
