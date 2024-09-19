using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercApp.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        // Propiedad de navegación: Un Rol puede estar asociado con muchos Usuarios
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
