using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class NewsModel
    {
        public int id;
        public string heading;
        public string firstText;
        public string secondText;
        public string image;
        public List<ArticleModel> paragraphs;

        public NewsModel()
        {
            id = -1;
            heading = "none";
            firstText = "no news";
            secondText = "err";
            image = "none";
            paragraphs = new List<ArticleModel>();
        }

        public NewsModel(int pid, string h, string f, string s, string img)
        {
            id = pid;
            heading = h;
            firstText = f;
            secondText = s;
            image = img;
        }
    }
}
