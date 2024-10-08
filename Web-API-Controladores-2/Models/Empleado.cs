﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_API_Controladores_2.Models
{
    public class Empleado
    {
        // ATRIBUTOS:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpleado { get; set; }


        [Required]
        public string Nombre { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public double Salaraio { get; set; }


        [Required]
        public DateTime FechaNacimiento { get; set; }


        [Required]
        public string Email { get; set; }

    }
}
