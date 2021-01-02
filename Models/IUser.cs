using System.Collections.Generic;

namespace jwt_01.Models
{
  public interface IUser {
    public int id { get;set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string role { get; set; }
  }
}