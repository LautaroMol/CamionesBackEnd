using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Amortizacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdAmortizacion {  get; set; }
        [Required]
        public int Plazo { get; set; }
        [Required]
        public int Periodo { get; set; }
        [Required]
        public float Objetivo { get; set; }
        [Required]
        public float ObjetivoAnual { get; set; }
        [Required]
        public float Porcentaje { get; set; }
        [Required]
        public float Recaudado { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
    }
}
