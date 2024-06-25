using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Carga
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdCarga { get; set; }
        [Required]
        public int Codigo { get; set; }
        public required string Producto { get; set; }
        [Required]
        public double Cantidad { get; set; }
        [Required]
        public string UnidadDeMedida { get; set; } = null!;
        [Required]
        public double PrecioUnit { get; set; }
        [Required]
        public double Bonif { get; set; }
        [Required]
        public double Subtotal { get; set; }
        [Required]
        public double Iva { get; set; }
        [Required]
        public bool? Borrado { get; set; }
        public int IdViaje { get; set; }
    }
}
