using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Factura
    {
        [Key]
        public int Idcliente { get; set; }
        [Required]
        public string RazonSoc { get; set; } = null!;
        [Required]
        public string Domicilio { get; set; } = null!;
        [Required]
        public string Condicion { get; set; } = null!;
        [Required]
        public string Cuit { get; set; } = null!;
        public bool? Borrado { get; set; }
    }
}
