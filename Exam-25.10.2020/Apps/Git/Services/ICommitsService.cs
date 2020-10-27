using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        string Create(string commit, string userId, string repoId);

        IEnumerable<AllCommitsVIewModel> GetAll(string userId);

        bool Delete(string userId);

        bool IsUserCreator(string userId, string commitId);
    }
}
