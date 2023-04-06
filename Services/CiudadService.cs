using ProyectoRest.ModelosC;
namespace ProyectoRest.Services;


public class CiudadService:ICiudadService
{

  UsuarioDbContext context;

  public CiudadService(UsuarioDbContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<Ciudad> Get()
  {
    return context.Ciudades;
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


  public async Task Update(Guid id, Ciudad ciudad)
  {
    var ciudadActual = context.Ciudades.Find(id);

    if(ciudadActual != null)
    {

      ciudadActual.Descripcion= ciudad.Descripcion;
      
      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(Guid id)
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
  IEnumerable<Ciudad> Get();
  Task Save(Ciudad ciudad);
  //void Save(Ciudad ciudad);
  Task Update(Guid id, Ciudad ciudad);
  Task Delete(Guid id);
  
}