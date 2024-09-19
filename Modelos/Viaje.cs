using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Viaje
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdViaje { get; set; }

        [Required]
        public string Inicio { get; set; } = null!;

        [Required]
        public string Final { get; set; } = null!;

        public List<int> Gastos { get; set; } = new List<int>();

        [Required]
        public DateOnly Fecha { get; set; }
        public string? Cp { get; set; }

        public bool Facturado { get; set; }

        public int CuitUsuario { get; set; }

        [Required]
        public float Distancia { get; set; }

        public bool? Borrado { get; set; }

        public float TotalFacturado { get; set; }
    }
}
