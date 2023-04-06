using System;
using System.Collections.Generic;

namespace ProyectoRest.ModelosC
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdCiudad { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdProvincia { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
