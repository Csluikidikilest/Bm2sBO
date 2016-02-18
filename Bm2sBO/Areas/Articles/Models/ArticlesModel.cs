﻿using Bm2s.Connectivity.Common.Article;

namespace Bm2sBO.Areas.Articles.Models
{
  public class ArticlesModel
  {
    public ArticlesModel()
    {
      this.Article = new Article();
      this.Get();
    }

    public Article Article { get; set; }

    public void Get()
    {
      this.Article.Get();
    }
  }
}