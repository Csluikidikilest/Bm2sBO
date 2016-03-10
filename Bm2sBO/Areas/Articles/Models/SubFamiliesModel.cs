using Bm2s.Connectivity.Common.Article;

namespace Bm2sBO.Areas.Articles.Models
{
  public class SubFamiliesModel
  {
    public SubFamiliesModel()
    {
      this.ArticleSubFamily = new ArticleSubFamily();
      this.Get();
    }

    public ArticleSubFamily ArticleSubFamily { get; set; }

    public void Get()
    {
      this.ArticleSubFamily.Get();
    }
  }
}
