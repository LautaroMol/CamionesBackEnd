using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Unidad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdUnidad {  get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public float Valoracion {  get; set; }
        [Required]
        public int Amortizacion { get; set; }
        [Required]
        public List<float> Ruedas { get; set; }
        [Required]
        public List<float> EstadoRueda { get; set; }
        [Required]
        public DateTime Aceite {  get; set; }
        [Required]
        public int KmAceite { get; set; }

    }
}
