using System;
using System.Collections.Generic;

namespace ProyectoRest.ModelosC
{
    public partial class Usuario
    {
        public string Nombre { get; set; } = null!;
        public int IdUser { get; set; }
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Telefono { get; set; }
        public int IdPais { get; set; }
        public int IdProvincia { get; set; }
        public int IdCiudad { get; set; }

        public virtual Ciudad IdCiudadNavigation { get; set; } = null!;
        public virtual Pais IdPaisNavigation { get; set; } = null!;
        public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
    }
}
