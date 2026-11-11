using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaValdiviaNueva.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Column("Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [StringLength(20)]
        [Column("Nit_Ci")]
        public string? NitCi { get; set; }

        [StringLength(20)]
        [Column("Telefono")]
        public string? Telefono { get; set; }
    }
}