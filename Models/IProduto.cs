namespace jwt_01.Models
{
  public interface IProduto {
    public int id { get; set; }
    public string name { get; set; }
    public double value { get; set; }
    public int userId { get; set; }
    public User user { get; set; }
  }
}