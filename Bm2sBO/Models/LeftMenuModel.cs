using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Bm2s.Poco.Common.User;

namespace Bm2sBO.Models
{
  public class LeftMenuModel
  {
    public LeftMenuModel()
    {
      User user = Utils.Utils.CurrentUser;
    }
  }
}
