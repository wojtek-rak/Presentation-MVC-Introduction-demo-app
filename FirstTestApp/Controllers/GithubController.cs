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

        //public IActionResult Index2()
        //{

        //    var mod = new GithubResultModel();
        //    var json = GithubApi.GetApi("wojtek-rak", "ApiReader");
        //    GithubResultModel githubModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GithubResultModel>(json);

        //    PropertyInfo[] properties = typeof(GithubResultModel).GetProperties();
        //    foreach (PropertyInfo property in properties)
        //    {
        //        var value = property.GetValue(githubModel);
        //    }
        //    //var githubViewModel = new GithubViewModel();
        //    //githubViewModel.GithubResultModel = githubModel;
        //    return View(githubModel);
        //}
        public IActionResult Index()
        {
        
            //var githubViewModel = new GithubViewModel();
            //githubViewModel.GithubResultModel = githubModel;
            return View(null);
        }

        [HttpPost]
        public IActionResult Index(GithubInputModel inputModel)
        {
            string userName = inputModel.UserName;//
            string repositoryName = inputModel.RepositoryName;//

            var mod = new GithubResultModel();
            var json = GithubApi.GetApi(userName, repositoryName);
            GithubResultModel githubModel = null;
            try
            {
                githubModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GithubResultModel>(json);
            }
            catch (Exception ex)
            {
                throw ex;
                //return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
            PropertyInfo[] properties = typeof(GithubResultModel).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(githubModel);
            }
            //var githubViewModel = new GithubViewModel();
            //githubViewModel.GithubResultModel = githubModel;
            return View(githubModel);
        }


    }
}