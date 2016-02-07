using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bm2s.Connectivity.Common.Article;
using Bm2s.Response.Common.Article.Article;

namespace Bm2sBO.Models
{
  public class ArticleModel
  {
    public ArticleModel()
    {
      this.Articles = new Article();
      this.Get();
    }

    public Article Articles { get; set; }

    public void Get()
    {
      this.Articles.Get();
    }

    public void Post()
    {
      this.Articles.Post();
    }
  }
}