using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercApp.Models
{
    public class PropietarioLocal
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public int LocalId { get; set; }
        [ForeignKey("LocalId")]
        public Local Local { get; set; }
    }
}
