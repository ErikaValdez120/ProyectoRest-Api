using ProyectoRest.ModelosC;
namespace ProyectoRest.Services;


public class CiudadService:ICiudadService
{

  UsuarioDbContext context;

  public CiudadService(UsuarioDbContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<CiudadDTO> Get()
  {
    return context.Ciudades.Select(x=>new CiudadDTO{
     idCiudad=x.IdCiudad, nombre = x.Descripcion, idProvincia= x.IdProvincia
    });
  }
  
  public async Task Save(Ciudad ciudad)
  {
      context.Add(ciudad);
      await context.SaveChangesAsync();
  }

  // public void Save(Provincia provincia)
  // {
  //     context.Add(provincia);
  //     context.SaveChanges();
  // }


  public async Task Update(int id, Ciudad ciudad)
  {
    var ciudadActual = context.Ciudades.Find(id);

    if(ciudadActual != null)
    {

      ciudadActual.Descripcion= ciudad.Descripcion;
      
      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(int id)
  {
    var ciudadActual = context.Ciudades.Find(id);

    if(ciudadActual != null)
    {
      context.Remove(ciudadActual);
      
      await context.SaveChangesAsync();
    }
  }

}

public interface ICiudadService
{
  IEnumerable<CiudadDTO> Get();
  Task Save(Ciudad ciudad);
  //void Save(Ciudad ciudad);
  Task Update(int id, Ciudad ciudad);
  Task Delete(int id);
  
}