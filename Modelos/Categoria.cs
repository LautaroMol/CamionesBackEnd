using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int Idcategoria { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;

        public bool? Borrado { get; set; }
    }
}
