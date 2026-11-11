using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerreteriaValdiviaNueva.Models
{
    [Table("Caja")]
    public class Caja
    {
        [Key]
        [Column("id_caja")]
        public int IdCaja { get; set; }

        [Required]
        [Column("FechaApertura")]
        public DateTime FechaApertura { get; set; }

        [Column("FechaCierre")]
        public DateTime? FechaCierre { get; set; }

        [Required]
        [Column("MontoInicial")]
        public decimal MontoInicial { get; set; }

        [Column("MontoFinal")]
        public decimal? MontoFinal { get; set; }

        [Required]
        [StringLength(50)]
        [Column("estado")]
        public string Estado { get; set; } = "Abierta";
    }
}