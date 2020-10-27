using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private ICommitsService commitsService;
        private IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userRepositoryName = this.repositoriesService.GetNameById(id);

            var model = new AddCommitViewModel() 
            { 
                Id = id, 
                Name = userRepositoryName,
            };
            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string description, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 3)
            {
                return this.Error("Description should be more then 3 characters");
            }

            this.commitsService.Create(description, this.GetUserId(), id);
            return this.Redirect("/Repositories/All");  
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            var commits = this.commitsService.GetAll(userId);
            return this.View(commits);
        }

        public HttpResponse Delete(string Id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (!this.commitsService.IsUserCreator(userId, Id))
            {
                return this.Error("You must be the author of this commit to remove it.");
            }

            this.commitsService.Delete(Id);
            return this.Redirect("/Commits/All");
        }
    }
}
