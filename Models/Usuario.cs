using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercApp.Models
{
    public class Usuario
    {
        [Key]
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
        [ForeignKey("IdGenero")]
        public Genero Genero { get; set; }

        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public Role Roles { get; set; }

        // Propiedad de navegación: Relación con la tabla intermedia PropietariosLocales
        public ICollection<PropietarioLocal> PropietariosLocales { get; set; }
    }
}
