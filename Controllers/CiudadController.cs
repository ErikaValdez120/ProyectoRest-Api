using Microsoft.AspNetCore.Mvc;
using ProyectoRest.ModelosC;
using ProyectoRest.Services;

namespace webapi.Controllers; 
//namespace proyectorest.Controllers;

[Route("api/[controller]")]

public class CiudadController : ControllerBase
{
  ICiudadService ciudadService;

  public CiudadController(ICiudadService service)
  {
    ciudadService = service;
  }

  [HttpGet]
  public IActionResult Get ()
  {

    return Ok(ciudadService.Get());

  }

  [HttpPost]

  public IActionResult Post([FromBody] CiudadDTO ciudadDTO)
  {   
      var ciudad = new Ciudad(){ Descripcion = ciudadDTO.descripcion,IdProvincia = ciudadDTO.idProvincia};
      ciudadService.Save(ciudad);
      return Ok();
  }

  [HttpPut ("{id}")]
  public IActionResult Put(int id,[FromBody] Ciudad ciudad)
  {
    ciudadService.Update(id,ciudad);
    return Ok();

  }

  [HttpDelete("{id}")]

  public IActionResult Delete(int id)
  {
    ciudadService.Delete(id);
    return Ok();
  }
}


