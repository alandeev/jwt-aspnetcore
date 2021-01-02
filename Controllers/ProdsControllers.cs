using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using jwt_01.Models;
using jwt_01.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace jwt_01.Controllers 
{
  [ApiController]
  [Route("v1/prods")]
  [Authorize]
  public class ProdsController: ControllerBase {
    
    [HttpPost]
    public async Task<ActionResult> addProduct( 
        [FromServices] IProdutoRepository prodContext,
        [FromServices] IUserRepository userContext,
        [FromBody] Produto data
      ) {
      
      var user_id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

      var user = await userContext.GetById(int.Parse(user_id));//falta por o id do user
      if(user == null){
        return BadRequest(new { TYPEERROR = "USER_NOT_FOUND" });
      }
      
      data.user = user;
      await prodContext.Add(data);
      return new ObjectResult(data) { StatusCode = 201 };
    }

    [HttpGet]
    public async Task<ActionResult<List<Produto>>> getProducts([FromServices] IProdutoRepository context) {
      var produtos = await context.GetAll();
      return new ObjectResult(produtos);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Produto>> getProdutoSpecifyById([FromServices] IProdutoRepository context, int id){
      var produto = await context.GetProduto(id);
      var StatusCode = produto == null ? 404 : 200;
      return new ObjectResult(produto) { StatusCode = StatusCode };
    }
  }
}
