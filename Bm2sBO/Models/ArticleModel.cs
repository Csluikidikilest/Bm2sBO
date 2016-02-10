using Bm2s.Connectivity.Common.Article;

namespace Bm2sBO.Models
{
  public class ArticleModel
  {
    public ArticleModel()
    {
      this.Articles = new Article();
      this.Get();
    }

    public ArticleModel(int id)
    {
      this.Articles = new Article();
      this.Articles.Request.Ids.Add(id);
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