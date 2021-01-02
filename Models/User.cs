using jwt_01.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace jwt_01.Models {
  public class User : IUser
  {
    [Key]
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string role { get; set; }
  }
}