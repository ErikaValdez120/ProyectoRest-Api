using System;
using System.Collections.Generic;

namespace ProyectoRest.ModelosC
{
    public partial class Provincia
    {
        public Provincia()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdProvincia { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdPais { get; set; }

        public virtual Pais IdPaisNavigation { get; set; } = null!;
        public virtual Ciudad Ciudad { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
