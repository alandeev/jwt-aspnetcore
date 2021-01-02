using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using jwt_01.Models;
using jwt_01.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;

namespace jwt_01.Controllers
{
  [ApiController]
  [Route("v1/users")]
  [Authorize]
  public class UserControllers: ControllerBase {

    [HttpGet]
    [Route("oauth")]
    public async Task<ActionResult<User>> oAuth([FromServices] IUserRepository userRepository){
      var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await userRepository.GetById(Int16.Parse(id));
      if(user == null){
        return NotFound();
      }

      return user;
    }

    [HttpGet]
    public async Task<List<User>> getUsers(
      [FromServices] IUserRepository userContext
    ){
      var users = await userContext.ToListAsync();
      return users;
    }

    [HttpGet]
    public async Task<ActionResult<User>> getUserById(
        [FromServices] IUserRepository userContext,
        [FromServices] IProdutoRepository prodContext
      ){
      var user_id = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

      var user = await userContext.GetById(user_id);
      if(user == null ){ return NotFound(); }
      
      var products = await prodContext.GetProdutosByUserId(user_id);

      return new ObjectResult(new { user, products });
    }
  }
}