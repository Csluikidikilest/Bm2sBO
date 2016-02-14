using System.Collections.Generic;
using System.Linq;
using Bm2s.Poco.Common.User;
using Bm2sBO.Utils;
using static Bm2sBO.Utils.Utils;

namespace Bm2sBO.Models
{
  public class LeftMenuModel
  {
    private List<Module> _modules;

    public LeftMenuModel()
    {
      this._modules = AuthorizationUtils.ModulesAuthorization();
    }

    public string ModuleName(Modules moduleCode)
    {
      string result = string.Empty;
      Module module = this._modules.FirstOrDefault(item => item.Code.ToLower() == moduleCode.ToString().ToLower());
      if(module != null)
      {
        result = module.Name;
      }

      return result;
    }
  }
}
