using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoRest.Models;

public class Categoria
{
    public Guid CategoriaId {get;set;}
    public string Nombre {get;set;} = null!;
    public string Descripcion {get;set;} = null!;
    public int Peso {get;set;}

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;} = null!;
}