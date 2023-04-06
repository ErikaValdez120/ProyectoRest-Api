using ProyectoRest.ModelosC;
namespace ProyectoRest.Services;


public class UsuarioService:IUsuarioService
{

  UsuarioDbContext context;

  public UsuarioService(UsuarioDbContext dbcontext)
  {
    context = dbcontext;
  }

  public IEnumerable<UsuarioDTO> Get()
  {
    return context.Usuarioss.Select(x=>new UsuarioDTO{
      nombre= x.Nombre,apellido=x.Apellido,telefono=x.Telefono,email=x.Email
    });
  }
  
  public async Task Save(Usuario usuario)
  {
      context.Add(usuario);
      await context.SaveChangesAsync();
  }

  public async Task Update(int id, Usuario usuario)
  {
    var usuarioActual = context.Usuarioss.Find(id);

    if(usuarioActual != null)
    {

      usuarioActual.Nombre= usuario.Nombre;
      usuarioActual.Apellido= usuario.Apellido;
      usuarioActual.Email=usuario.Email;
      usuarioActual.Telefono= usuario.Telefono;
      usuarioActual.IdPais = usuario.IdPais;
      usuarioActual.IdProvincia= usuario.IdProvincia;
      usuarioActual.IdCiudad=usuario.IdCiudad;

      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(int id)
  {
    var usuarioActual = context.Usuarioss.Find(id);

    if(usuarioActual != null)
    {
      context.Remove(usuarioActual);
      
      await context.SaveChangesAsync();
    }
  }

}

public interface IUsuarioService
{
  IEnumerable<UsuarioDTO> Get();
  Task Save(Usuario usuario);
  Task Update(int id, Usuario usuario);
  Task Delete(int id);
  
}

