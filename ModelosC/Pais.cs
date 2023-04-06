using ProyectoRest.Models;
using System;
using System.Collections.Generic;

namespace ProyectoRest.ModelosC
{
    public partial class Pais
    {
        public Pais()
        {
            Provincia = new HashSet<Provincia>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPais { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Provincia> Provincia { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
