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
using System.Diagnostics;

namespace FirstTestApp.Controllers
{
    public class GithubController : Controller
    {

        public IActionResult Index()
        {
            return View(null);
        }

        [HttpPost]
        public IActionResult Index(GithubInputModel inputModel)
        {
            string userName = inputModel.UserName;
            string repositoryName = inputModel.RepositoryName;

            var mod = new GithubResultModel();
            var json = GithubApi.GetApi(userName, repositoryName);
            GithubResultModel githubModel = null;
            try
            {
                //var b = new List<int>();
                //Console.Write(b[4]);
                githubModel = Newtonsoft.Json.JsonConvert.DeserializeObject<GithubResultModel>(json);
            }
            catch (Exception ex)
            {
                throw ex;
                //return View("Error", new ErrorViewModel { ExMessage = ex.Message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View(githubModel);
        }

    }
}