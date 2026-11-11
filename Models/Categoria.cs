using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaValdiviaNueva.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column("id_Categoria")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(100)]
        [Column("Nombre_Categoria")]
        public string NombreCategoria { get; set; } = string.Empty;

        public virtual ICollection<Producto>? Productos { get; set; }
    }
}