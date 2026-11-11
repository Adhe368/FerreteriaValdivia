using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaValdiviaNueva.Models
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        [StringLength(50)]
        [Column("CodigoProducto")]
        public string CodigoProducto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100)]
        [Column("Nombre_Producto")]
        public string Nombre_Producto { get; set; } = string.Empty;

        [Required]
        [Column("PrecioVenta", TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }

        [Column("StockMinimo")]
        public int StockMinimo { get; set; }

        [Column("StockActual")]
        public int StockActual { get; set; }

        [Column("CantidadVendida")]
        public int CantidadVendida { get; set; }

        [Column("id_Categoria")]
        public int? id_Categoria { get; set; }

        [ForeignKey("id_Categoria")]
        public virtual Categoria? Categoria { get; set; }

        [Column("id_Proveedor")]
        public int? id_Proveedor { get; set; }

        [ForeignKey("id_Proveedor")]
        public virtual Proveedor? Proveedor { get; set; }
    }
}