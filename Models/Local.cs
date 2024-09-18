using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercApp.Models
{
    public class Local
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Propiedad de navegación: Relación con la tabla intermedia PropietariosLocales
        public ICollection<PropietarioLocal> PropietariosLocales { get; set; }
    }
}
