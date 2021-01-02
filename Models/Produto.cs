using System.ComponentModel.DataAnnotations;

namespace jwt_01.Models
{
  public class Produto: IProduto {

    [Key]
    public int id { get; set; }
    
    [Required(ErrorMessage = "Esse campo é obrigatorio")]
    [MinLength(4, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
    [MaxLength(12, ErrorMessage = "Esse campo precisa ter entre 4 a 12 caracteres")]
    public string name { get; set; }

    [Range(5.0, 100, ErrorMessage = "O valor precisa ter entre 5.0 e 100.0")]
    public double value { get; set; }

    //user configs

    [Required]
    public int userId { get; set; }
    public User user { get; set; }
  }   
}