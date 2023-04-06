using ProyectoRest.ModelosC;
namespace ProyectoRest.Services;


public class ProvinciaService:IProvinciaService
{

  UsuarioDbContext context;

  public ProvinciaService(UsuarioDbContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<ProvinciaDTO> Get()
  {
    return context.Provincias.Select(X=>new ProvinciaDTO{
    descripcion=X.Descripcion,idPais=X.IdPais
    });
  }
  
  // public void Save(Provincia provincia)
  // {
  //     context.Add(provincia);
  //     context.SaveChanges();
  // }

  public async Task Save(Provincia provincia)
  {
      context.Add(provincia);
      await context.SaveChangesAsync();
  }


  public async Task Update(int id, Provincia provincia)
  {
    var provinciaActual = context.Provincias.Find(id);

    if(provinciaActual != null)
    {

      provinciaActual.Descripcion= provincia.Descripcion;
      
      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(int id)
  {
    var provinciaActual = context.Provincias.Find(id);

    if(provinciaActual != null)
    {
      context.Remove(provinciaActual);
      
      await context.SaveChangesAsync();
    }
  }

}

public interface IProvinciaService
{
  IEnumerable<ProvinciaDTO> Get();
  //void Save(Provincia provincia);
  Task Save(Provincia provincia);
  Task Update(int id, Provincia provincia);
  Task Delete(int id);
  
}