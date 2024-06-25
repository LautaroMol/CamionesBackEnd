using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdFactura { get; set; }
        [Required]
        public int CuitUsuario { get; set; }
        [Required]
        public int CuitCliente { get; set; }
        [Required]
        public List<int> Cargas { get; set; }
        [Required]
        public string Cuit { get; set; } = null!;
        
        public bool? Borrado { get; set; }

    }
}
