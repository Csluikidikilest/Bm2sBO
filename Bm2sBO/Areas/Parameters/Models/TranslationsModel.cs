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
      this.Translation = new Translation();
      this.Translation.Request.Application = TranslationUtils.ApplicationName;
      this.Translation.Request.PageSize = 0;
      this.Get();
    }

    public TranslationsModel(int id)
    {
      this.Language = new Language();
      this.Translation = new Translation();
      this.Translation.Request.Application = TranslationUtils.ApplicationName;
      this.Translation.Request.Ids.Add(id);
      this.Get();
    }

    public Language Language { get; set; }

    public Translation Translation { get; set; }

    public void Get()
    {
      this.Language.Get();
      this.Translation.Get();
    }

    public void Post()
    {
      this.Translation.Post();
    }
  }
}