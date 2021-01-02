using System.Collections.Generic;
using jwt_01.Data;
using jwt_01.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace jwt_01.Repositories
{
  public class UserRepository : IUserRepository
  {
    public readonly DataContext context;
    public UserRepository(DataContext _context){
      Console.WriteLine("Foi executado o UserRepository");
      context = _context;
    }

    public void Create(User data) {
      context.Users.Add(data);
      context.SaveChanges();
    }

    public async Task<User> GetById(int id) {
      var user = await context.Users.FindAsync(id);
      return user;
    }

    public async Task<List<User>> ToListAsync() {
      var users = await context.Users.ToListAsync();
      return users;
    }

    public async Task<User> FindByEmailAsync(string email){
      var user = await context.Users.Where(user => user.email == email).FirstOrDefaultAsync();
      return user;
    }
  }
}