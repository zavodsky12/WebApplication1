using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using System.Data.SqlClient;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<NewsModel> newsList = new List<NewsModel>();

            NewsDAO newsDAO = new NewsDAO();

            newsList = newsDAO.GetAllNews();

            return View("Index", newsList);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void returnAllNews()
        {
            //connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=minvolley;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //sql expression
            string queryString = "SELECT * from dbo.articles";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool success = false;

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@number", System.Data.SqlDbType.Int).Value = 1;

                //open database and run the command
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Nemame data");
                    throw;
                }
            }
        }
    }
}
