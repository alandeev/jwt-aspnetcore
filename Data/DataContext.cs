using Microsoft.EntityFrameworkCore;
using jwt_01.Models;

namespace jwt_01.Data
{
    public class DataContext: DbContext {
      public DataContext (DbContextOptions<DataContext> options): base(options){ }
      public DbSet<Produto> Produtos { get; set; }
      public DbSet<User> Users { get; set; }
    }
}