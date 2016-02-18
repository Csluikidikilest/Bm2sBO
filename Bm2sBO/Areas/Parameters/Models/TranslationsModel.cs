using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bm2s.Connectivity.Common.Parameter;
using Bm2sBO.Utils;

namespace Bm2sBO.Areas.Parameters.Models
{
  public class TranslationsModel
  {
    public TranslationsModel()
    {
      this.Language = new Language();
      this.Get();
    }

    public Language Language { get; set; }

    public void Get()
    {
      this.Language.Get();
    }
  }
}