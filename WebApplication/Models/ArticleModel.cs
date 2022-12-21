using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ArticleModel
    {
        public int id;
        public int articleId;
        public string paragraph;

        public ArticleModel()
        {
            id = -1;
            articleId = -2;
        }

        public ArticleModel(int pid, int aid, string paras)
        {
            id = pid;
            articleId = aid;
            paragraph = paras;
        }
    }
}
