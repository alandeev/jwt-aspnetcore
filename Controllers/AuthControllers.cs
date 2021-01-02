// using Microsoft.AspNetCore;
using jwt_01.Models;
using jwt_01.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using jwt_01.Services;

namespace jwt_01.Controllers
{
  [ApiController]
  [Route("v1")]
  public class AuthController: ControllerBase {

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> authenticate(
      [FromServices] IUserRepository userData,
      [FromBody] UserViewModelAuthenticate model
    ){  
      if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

      var user = await userData.FindByEmailAsync(model.email);
      
      if(user == null){
        return new ObjectResult(new{ error = "User not found"}) { StatusCode = 401 };
      }
      
      if(user.password != model.password){
        return new ObjectResult(new{ error = "Password is invalid"}) { StatusCode = 401 };
      }

      var token = TokenService.GenerateToken(user);

      return new ObjectResult( new {
        user = user,
        token = token
      });
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public ActionResult<UserViewModelRegister> createUser(
      [FromServices] IUserRepository context,
      [FromBody] UserViewModelRegister model
    ){
      if(!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

      var user = new User {
        name = model.name,
        email = model.email,
        password = model.password,
        role = model.role
      };

      try{

        context.Create(user);

        return model;
      } catch {
        return BadRequest();
      }
    }
  }
}