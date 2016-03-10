using Bm2s.Connectivity.Common.Article;

namespace Bm2sBO.Areas.Articles.Models
{
  public class BrandsModel
  {
    public BrandsModel()
    {
      this.Brand = new Brand();
      this.Get();
    }

    public Brand Brand { get; set; }

    public void Get()
    {
      this.Brand.Get();
    }
  }
}
