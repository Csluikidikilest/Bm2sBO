using Bm2s.Connectivity.Common.Article;

namespace Bm2sBO.Areas.Articles.Models
{
  public class FamiliesModel
  {
    public FamiliesModel()
    {
      this.ArticleFamily = new ArticleFamily();
      this.Get();
    }

    public ArticleFamily ArticleFamily { get; set; }

    public void Get()
    {
      this.ArticleFamily.Get();
    }
  }
}
