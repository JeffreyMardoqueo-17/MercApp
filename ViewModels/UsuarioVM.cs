using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercApp.Models;

namespace MercApp.ViewModels
{
    public class UsuarioVM
    {

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Pass { get; set; }
        public string ConfirmarPass { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Relaciones y claves foráneas
        public int IdGenero { get; set; }
        public Genero Genero { get; set; }

        public int IdRol { get; set; }
        public Rol Rol { get; set; }

        // Propiedad de navegación: Relación con la tabla intermedia PropietariosLocales
        public ICollection<PropietarioLocal> PropietariosLocales { get; set; }
    }
}