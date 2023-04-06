using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRest.Models;

public class Tarea
{
    public Guid TareaId {get;set;}
    public Guid CategoriaId {get;set;}
    public string Titulo {get;set;} = null!;
    public string Descripcion {get;set;} = null!;
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}    
    public virtual Categoria Categoria {get;set;} = null!;
    public string Resumen {get;set;} = null!;
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}