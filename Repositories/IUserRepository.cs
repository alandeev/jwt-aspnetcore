using jwt_01.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jwt_01.Repositories
{
  public interface IUserRepository {
    public void Create(User produto);
    public Task<List<User>> ToListAsync();
    public Task<User> GetById(int id);
    public Task<User> FindByEmailAsync(string email);
  }
}