using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Git.ViewModels.Commits
{
    public class AllCommitsVIewModel
    {
        public string Id { get; set; }

        public string Repository { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public string Description { get; set; }
    }
}
