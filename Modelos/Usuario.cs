using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdUsuario { get; set; }
        [Required]
        public string Razon { get; set; } = null!;
        [Required]
        public string Domicilio { get; set; } = null!;
        [Required]
        public string Condicion { get; set; } = null!;
        [Required]
        public string Cuit { get; set; } = null!;
        public List<int>? Facturas { get; set; }
        public bool? Borrado { get; set; }
    }
}
