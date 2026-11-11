using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaValdiviaNueva.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        [Column("id_Empleado")]
        public int IdEmpleado { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Column("Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [StringLength(20)]
        [Column("Telefono")]
        public string? Telefono { get; set; }

        [Column("id_Rol")]
        public int? IdRol { get; set; }

        [ForeignKey("IdRol")]
        public virtual Rol? Rol { get; set; }
    }
}