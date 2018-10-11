using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTestApp.Models
{
    public class GithubResultModel
    {
        public string full_name { get; set; }
        public string description { get; set; }
        public string clone_url { get; set; }
        public string language { get; set; }
        public string open_issues_count { get; set; }
        public string watchers { get; set; }
    }
}
