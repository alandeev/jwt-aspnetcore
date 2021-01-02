using jwt_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jwt_01.Repositories
{
  public interface IProdutoRepository {
    public Task<bool> Add(Produto produto);
    public Task<List<Produto>> GetAll();
    public Task<Produto> GetProduto(int id);
    public Task<List<Produto>> GetProdutosByUserId(int id);
  }
}