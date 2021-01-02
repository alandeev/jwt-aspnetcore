using System.Collections.Generic;
using jwt_01.Data;
using jwt_01.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace jwt_01.Repositories
{
  public class ProdutoRepository : IProdutoRepository
  {
    public readonly DataContext context;
    public ProdutoRepository(DataContext _context){
      Console.WriteLine("Foi executado o ProdutoRepository");
      context = _context;
    }

    public async Task<bool> Add(Produto produto) {
      context.Produtos.Add(produto);
      await context.SaveChangesAsync();
      Console.WriteLine("CRIOU '-'");
      return true;
    }
    public async Task<List<Produto>> GetAll() {
      var produtos = await context.Produtos
      .Include(prod => prod.user) 
      .ToListAsync();
      return produtos;
    }

    public async Task<Produto> GetProduto(int id) {
      return await context.Produtos
      .Where(prod => prod.id == id)
      .Include(prod => prod.user)
      .FirstOrDefaultAsync();
    }    

    public async Task<List<Produto>> GetProdutosByUserId(int id){
      var products =  await context.Produtos
      .AsNoTracking()
      .Where(x => x.userId == id)
      .ToListAsync();

      return products;
    }
  }
}