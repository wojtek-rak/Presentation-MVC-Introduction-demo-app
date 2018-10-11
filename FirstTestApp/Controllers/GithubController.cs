using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using FirstTestApp.Models;

namespace FirstTestApp.Controllers
{
    public class GithubController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        //public IEnumerable<GitHubBranch> Branches { get; private set; }

        public bool GetBranchesError { get; private set; }

        public IActionResult Index()
        {

            var mod = new GithubResultModel();
            var json = GithubApi.GetApi("wojtek-rak", "ApiReader");
            GithubResultModel githubModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GithubResultModel>(json);

            PropertyInfo[] properties = typeof(GithubResultModel).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(githubModel);
            }

            return View(githubModel);
        }



    }
}