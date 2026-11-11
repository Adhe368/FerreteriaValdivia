using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaValdiviaNueva.Models
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        [Column("id_Proveedor")]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio.")]
        [StringLength(100)]
        [Column("Nombre_Proveedor")]
        public string NombreProveedor { get; set; } = string.Empty;

        [StringLength(20)]
        [Column("Telefono")]
        public string? Telefono { get; set; }

        [StringLength(150)]
        [Column("Direccion")]
        public string? Direccion { get; set; }

        public virtual ICollection<Producto>? Productos { get; set; }
    }
}