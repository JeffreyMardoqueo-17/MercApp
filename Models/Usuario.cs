using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        public string Telefono { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Pass { get; set; }

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
