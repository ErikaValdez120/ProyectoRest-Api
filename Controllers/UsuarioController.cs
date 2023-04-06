using Microsoft.AspNetCore.Mvc;
using ProyectoRest.ModelosC;
using ProyectoRest.Services;

namespace ProyectoRest.Controllers; 
//namespace proyectorest.Controllers;
[ApiController]
[Route("api/[controller]")]

public class UsuarioController : ControllerBase
{
  IUsuarioService usuarioService;
  UsuarioDbContext usuariocontext;


  public UsuarioController(IUsuarioService service,UsuarioDbContext contextdb)
  {
    usuarioService = service;
    usuariocontext= contextdb;

  }

  [HttpGet]
  
  public IActionResult Get ()
  {

    return Ok(usuarioService.Get());

  }

 

  [HttpPost]

  public IActionResult Post([FromBody] Usuario usuario)
  {
      usuarioService.Save(usuario);
      return Ok();
  }

  [HttpPut ("{id}")]
  public IActionResult Put(int id,[FromBody] Usuario usuario)
  {
    usuarioService.Update(id,usuario);
    return Ok();

  }

  [HttpDelete("{id}")]

  public IActionResult Delete(int id)
  {
    usuarioService.Delete(id);
    return Ok();
  }

  [HttpGet]
  [Route ("createdbUsuario")]

  public IActionResult CreateDatabase()
  {
    usuariocontext.Database.EnsureCreated();

    return Ok();
  }

}


