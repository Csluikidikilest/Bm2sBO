using System.Security.Cryptography;
using System.Text;
using System.Web;
using Bm2s.Connectivity.Common.User;

namespace Bm2sBO.Models
{
  public class LoginModel
  {
    public string UserLogin { get; set; }

    public string Password { get; set; }

    public int OpenSession()
    {
      SHA512 hash = SHA512.Create();
      byte[] passwordBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(this.Password));

      StringBuilder password = new StringBuilder();
      foreach (byte passwordByte in passwordBytes)
      {
        password.Append(passwordByte.ToString("X2"));
      }

      Login login = new Login();
      login.Request.UserLogin = this.UserLogin;
      login.Request.Password = password.ToString();
      login.Get();
      HttpContext.Current.Session[LoginModel.SessionKey] = login.Response.User;
      return login.Response.User.Id;
    }
  }
}