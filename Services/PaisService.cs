using ProyectoRest.ModelosC;
namespace ProyectoRest.Services;


public class PaisService:IPaisService
{

  UsuarioDbContext context;

  public PaisService(UsuarioDbContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<PaisDTO> Get()
  {
    return context.Paises.Select(x=>new PaisDTO{
      idPaisDTO=x.IdPais,
      descripcion= x.Descripcion
    });
  }
  
  public async Task Save(Pais pais)
  {
      context.Add(pais);
      await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Pais pais)
  {
    var paisActual = context.Paises.Find(id);

    if(paisActual != null)
    {

      paisActual.Descripcion= pais.Descripcion;
      
      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(Guid id)
  {
    var paisActual = context.Paises.Find(id);

    if(paisActual != null)
    {
      context.Remove(paisActual);
      
      await context.SaveChangesAsync();
    }
  }

}

public interface IPaisService
{
  IEnumerable<PaisDTO> Get();
  Task Save(Pais pais);
  Task Update(Guid id, Pais pais);
  Task Delete(Guid id);
  
}