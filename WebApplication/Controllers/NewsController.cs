using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            var routeUrl = Request.Path;
            //var routeUrl = ViewContext.RouteData.Values["Action"].ToString();
            var qsPath = Request.QueryString.Value;
            var returnUrl = $"{routeUrl}{qsPath}";

            string[] tokens = qsPath.Split('=');
            string[] resTokens;
            if (tokens.Length < 2)
            {
                resTokens = new string[2] { "1", "1" };
            }
            else
            {
                resTokens = tokens[1].Split('/');
            }
            int idcko = Int32.Parse(resTokens[0]);

            List<NewsModel> newsList = new List<NewsModel>();

            NewsDAO newsDAO = new NewsDAO();

            newsList = newsDAO.GetTopNews(idcko);

            return View("Index", newsList);
        }
    }
}
