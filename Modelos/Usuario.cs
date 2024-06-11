using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Usuario
    {
        [Key]
        public int Idusuario { get; set; }
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
