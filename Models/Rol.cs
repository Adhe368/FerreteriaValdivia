using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaValdiviaNueva.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        [Column("id_Rol")]
        public int IdRol { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Nombre_Rol")]
        public string NombreRol { get; set; } = string.Empty;

        public virtual ICollection<Empleado>? Empleados { get; set; }
    }
}