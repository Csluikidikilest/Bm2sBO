using Bm2s.Connectivity.Common.Article;

namespace Bm2sBO.Areas.Articles.Models
{
  public class NomenclatureModel
  {
    public NomenclatureModel()
    {
      this.Nomenclature = new Nomenclature();
      this.Get();
    }

    public Nomenclature Nomenclature { get; set; }

    public void Get()
    {
      this.Nomenclature.Get();
    }
  }
}
