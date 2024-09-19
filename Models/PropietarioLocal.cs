using System.ComponentModel.DataAnnotations;

namespace MercApp.Models
{
    public class PropietarioLocal
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int LocalId { get; set; }
        public Local Local { get; set; }
    }
}
