using System.ComponentModel.DataAnnotations;

namespace API_Camiones.Modelos
{
    public class Categoria
    {
        [Key]
        public int Idcategoria { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;

        public bool? Borrado { get; set; }
    }
}
