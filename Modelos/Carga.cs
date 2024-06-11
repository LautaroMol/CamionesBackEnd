using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Carga
    {
        [Key]
        public int Idcarga { get; set; }
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
