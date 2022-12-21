using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class NewsDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=minvolley;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<NewsModel> GetAllNews()
        {

            List<NewsModel> returnList = new List<NewsModel>();

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool success = false;

                //sql expression
                string queryString = "SELECT TOP 6 * from dbo.articles ORDER BY Id DESC";

                SqlCommand command = new SqlCommand(queryString, connection);

                //command.Parameters.Add("@number", System.Data.SqlDbType.Int).Value = 1;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NewsModel news = new NewsModel();
                        news.id = reader.GetInt32(0);
                        news.heading = reader.GetString(1);
                        news.firstText = reader.GetString(2);
                        //news.secondText = reader.GetString(3);
                        news.image = reader.GetString(4);

                        returnList.Add(news);
                    }
                }
            }
            return returnList;
        }

        public List<NewsModel> GetTopNews(int pgNumber)
        {

            List<NewsModel> returnList = new List<NewsModel>();

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool success = false;

                //sql expression
                string queryString = "SELECT * from dbo.articles ORDER BY Id DESC";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@myId", System.Data.SqlDbType.Int).Value = pgNumber;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    for (int i = 0; i < (pgNumber - 1) * 7; i++)
                    {
                        reader.Read();
                    }
                    int j = 0;
                    while (reader.Read() && j < 7)
                    {
                        NewsModel news = new NewsModel();
                        news.id = reader.GetInt32(0);
                        news.heading = reader.GetString(1);
                        news.firstText = reader.GetString(2);
                        //news.secondText = reader.GetString(3);
                        news.image = reader.GetString(4);

                        returnList.Add(news);
                        j++;
                    }
                }
            }
            return returnList;
        }

        public NewsModel GetSingleNews(int pid)
        {
            NewsModel returnElement = new NewsModel();

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool success = false;

                //sql expression
                string queryString = "SELECT * from dbo.articles WHERE id = @myId ORDER BY Id DESC";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@myId", System.Data.SqlDbType.Int).Value = pid;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NewsModel news = new NewsModel();
                        news.id = reader.GetInt32(0);
                        news.heading = reader.GetString(1);
                        news.firstText = reader.GetString(2);
                        //news.secondText = reader.GetString(3);
                        news.image = reader.GetString(4);

                        returnElement = news;
                    }
                }
            }
            return returnElement;
        }

        public List<ArticleModel> GetAllParagraps(int pid)
        {
            List<ArticleModel> returnList = new List<ArticleModel>();

            //access database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool success = false;

                //sql expression
                string queryString = "SELECT * from dbo.paragraph WHERE articleId = @myId ORDER BY Id";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@myId", System.Data.SqlDbType.Int).Value = pid;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ArticleModel article = new ArticleModel();
                        article.id = reader.GetInt32(0);
                        article.articleId = reader.GetInt32(1);
                        article.paragraph = reader.GetString(2);

                        returnList.Add(article);
                    }
                }
            }
            return returnList;
        }
    }
}
