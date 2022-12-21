using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using System.Configuration;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ArticleController : Controller
    {

        public IActionResult Index()
        {
            var routeUrl = Request.Path;
            //var routeUrl = ViewContext.RouteData.Values["Action"].ToString();
            var qsPath = Request.QueryString.Value;
            var returnUrl = $"{routeUrl}{qsPath}";

            string[] tokens = qsPath.Split('=');
            string[] resTokens = tokens[1].Split('/');
            int idcko = Int32.Parse(resTokens[0]);

            NewsModel newsModel = new NewsModel();

            NewsDAO newsDAO = new NewsDAO();

            newsModel = newsDAO.GetSingleNews(idcko);

            List<ArticleModel> articleModel = new List<ArticleModel>();

            articleModel = newsDAO.GetAllParagraps(idcko);

            newsModel.paragraphs = articleModel;

            return View("Index", newsModel);
        }
    }
}
