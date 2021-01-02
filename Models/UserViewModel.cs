using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace jwt_01.Models
{
    public class UserViewModelAuthenticate {
      [Required(ErrorMessage = "Esse campo é obrigatorio")]
      [EmailAddress(ErrorMessage = "Esse campo não é um E-mail valido")]
      public string email { get; set; }
      
      [Required(ErrorMessage = "Esse campo é obrigatorio")]
      [MinLength(4, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
      [MaxLength(12, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
      public string password { get; set; }
    }

    public class UserViewModelRegister {

    [Required(ErrorMessage = "Esse campo é obrigatorio")]
    [MinLength(4, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
    [MaxLength(12, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
    public string name { get; set; }

    [Required(ErrorMessage = "Esse campo é obrigatorio")]
    [EmailAddress(ErrorMessage = "Esse campo não é um E-mail valido")]
    public string email { get; set; }
    
    [Required(ErrorMessage = "Esse campo é obrigatorio")]
    [MinLength(4, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
    [MaxLength(12, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
    public string password { get; set; }

    [Required]
    public string role { get; set; }
    }
}