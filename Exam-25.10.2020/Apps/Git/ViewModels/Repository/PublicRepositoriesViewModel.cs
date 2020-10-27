using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Git.ViewModels.Repository
{
    public class PublicRepositoriesViewModel
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public string CreatedOnAsString => this.CreatedOn.ToString(CultureInfo.GetCultureInfo("bg-BG"));

        public int CommitsCount { get; set; }

        public string Commit { get; set; }

        public string Id { get; set; }
    }
}
