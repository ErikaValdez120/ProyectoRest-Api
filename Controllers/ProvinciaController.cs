using Microsoft.AspNetCore.Mvc;
using ProyectoRest.ModelosC;
using ProyectoRest.Services;

namespace webapi.Controllers; 
//namespace proyectorest.Controllers;

[Route("api/[controller]")]

public class ProvinciaController : ControllerBase
{
  IProvinciaService provinciaService;

  public ProvinciaController(IProvinciaService service)
  {
    provinciaService = service;
  }

  [HttpGet]
  public IActionResult Get ()
  {

    return Ok(provinciaService.Get());

  }

  [HttpPost]

  public IActionResult Post([FromBody] ProvinciaDTO provinciaDTO)
  {
      var provincia = new Provincia(){ Descripcion= provinciaDTO.descripcion,IdPais=provinciaDTO.idPais};
     provinciaService.Save(provincia);
      return Ok();
  }

  [HttpPut ("{id}")]
  public IActionResult Put(int id,[FromBody] Provincia provincia)
  {
    provinciaService.Update(id,provincia);
    return Ok();

  }

  [HttpDelete("{id}")]

  public IActionResult Delete(int id)
  {
    provinciaService.Delete(id);
    return Ok();
  }
}


