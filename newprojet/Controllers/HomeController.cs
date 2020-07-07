using System.Collections.Generic;
using System.Linq;
using System;
using newprojet.models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using newprojet.Services;
using newprojet.Repositories;

namespace newprojet.Controllers
{
  [Route("v1/account")]
  public class HomeController : ControllerBase
  {
     
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
  
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
    {
      var user =  UserRepository.Get(model.Username, model.Password);
      
      if (user == null)
          return NotFound( new {message = "usuário ou senha inválidos"});

        var token = TokenSevice.GenerateToken(user);
        user.Password = "";
        return new {
            user,
            token
        };

    }

    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]

    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]

     public string Authenticated () => String.Format("Autenticado - {0}", User.Identity.Name);

     
    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee, manager")]

     public string Employee () => "Funcionário";

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "manager")]

     public string Manager () => "Gerente";


  }
}