using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Gasto
    {
        [Key]
        public int Idgasto { get; set; }
        public required string Nombre { get; set; }
        [Required]
        public double Cantidad { get; set; }
        [Required]
        public int? Categoria { get; set; }
        [Required]
        public int Viaje { get; set; }
        [Required]
        public DateOnly Fecha { get; set; }
        public bool? Borrado { get; set; }
    }
}
