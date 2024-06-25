using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Gasto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdGasto { get; set; }
        public required string Nombre { get; set; }
        [Required]
        public double Cantidad { get; set; }
        [Required]
        public int? Categoria { get; set; }
        [Required]
        public int Viaje { get; set; }
        [Required]
        public DateOnly Fecha { get; set; }
        public bool? Borrado { get; set; }
    }
}
