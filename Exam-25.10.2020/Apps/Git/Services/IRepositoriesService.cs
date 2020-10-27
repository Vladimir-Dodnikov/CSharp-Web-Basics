using Git.ViewModels.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        string Create(AddRepositoryInputModel repositoryInputModel, string userId);

        IEnumerable<PublicRepositoriesViewModel> GetAllPublicRepositories();

        string GetNameById(string id);
    }
}
