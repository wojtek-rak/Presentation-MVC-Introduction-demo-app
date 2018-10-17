using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FirstTestApp.Models
{
    public class GithubViewModel
    {
        public GithubResultModel GithubResultModel { get; set; }
        public GithubInputModel GithubInputModel { get; set; }
    }
}
