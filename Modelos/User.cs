using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdUser { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Pass {  get; set; }
    }
}
