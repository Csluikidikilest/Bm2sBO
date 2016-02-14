using Bm2sBO.Utils;

namespace Bm2sBO.Models
{
  public class LoginModel
  {
    public string UserLogin { get; set; }

    public string Password { get; set; }

    public int OpenSession()
    {
      return UserUtils.OpenSession(this.UserLogin, this.Password);
    }

    public bool CloseSession()
    {
      UserUtils.CloseSession();
      return UserUtils.CurrentUser.IsAnonymous;
    }
  }
}