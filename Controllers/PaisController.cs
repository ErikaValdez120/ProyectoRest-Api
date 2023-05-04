using Microsoft.AspNetCore.Mvc;
using ProyectoRest.ModelosC;
using ProyectoRest.Services;

namespace webapi.Controllers; 
//namespace proyectorest.Controllers;

[Route("api/[controller]")]

public class PaisController : ControllerBase
{
  IPaisService paisService;

  public PaisController(IPaisService service)
  {
    paisService = service;
  }

  [HttpGet]
  public IActionResult Get ()
  {

    return Ok(paisService.Get());

  }

  [HttpPost]

  public IActionResult Post([FromBody] PaisDTO paisDTO)
  {
      var pais = new Pais(){Descripcion = paisDTO.nombre};
      paisService.Save(pais);
      return Ok();
  }

  [HttpPut ("{id}")]
  public IActionResult Put(Guid id,[FromBody] Pais pais)
  {
    paisService.Update(id,pais);
    return Ok();

  }

  [HttpDelete("{id}")]

  public IActionResult Delete(Guid id)
  {
    paisService.Delete(id);
    return Ok();
  }
}


