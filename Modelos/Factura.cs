using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Factura
    {
        [Key]
        public int Idfactura { get; set; }
        [Required]
        public List<int> Usuarios { get; set; }
        [Required]
        public List<int> Clientes { get; set; }
        [Required]
        public List<int> Cargas { get; set; }
        [Required]
        public string Cuit { get; set; } = null!;
        
        public bool? Borrado { get; set; }

    }
}
