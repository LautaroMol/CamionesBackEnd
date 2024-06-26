﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Camiones.Modelos
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int IdCliente { get; set; }
        [Required]
        public string RazonSoc { get; set; } = null!;
        [Required]
        public string Domicilio { get; set; } = null!;
        [Required]
        public string Condicion { get; set; } = null!;
        [Required]
        public string CuitCliente { get; set; } = null!;
        public bool? Borrado { get; set; }

    }
}
