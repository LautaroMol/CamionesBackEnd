using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int Idfactura { get; set; }
        [Required]
        public int Usuario { get; set; }
        [Required]
        public int Cliente { get; set; }
        [Required]
        public List<int> Cargas { get; set; }
        [Required]
        public string Cuit { get; set; } = null!;
        
        public bool? Borrado { get; set; }

    }
}
