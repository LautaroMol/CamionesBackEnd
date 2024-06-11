using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Viaje
    {
        [Key]
        public int Idviaje { get; set; }
        [Required]
        public string Inicio { get; set; } = null!;
        [Required]
        public string Final { get; set; } = null!;
        [Required]
        public List<int>? Gastos { get; set; }
        [Required]
        public DateOnly Fecha { get; set; }
        [Required]
        public int Cp { get; set; }
        public bool Facturado { get; set; }
        public int CuitUsuario { get; set; }
        [Required]
        public int Distancia { get; set; }
        [Required]
        public bool? Borrado { get; set; }
    }
}
