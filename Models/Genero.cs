using System.ComponentModel.DataAnnotations;

namespace MercApp.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        // Propiedad de navegación: Un Género puede estar asociado con muchos Usuarios
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
