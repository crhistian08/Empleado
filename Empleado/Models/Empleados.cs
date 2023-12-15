using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Empleado.Models
{
    public class Empleados
    {
        [Column("Cedula")]
        [Required(ErrorMessage = "La Cedula es obligatoria.")]
        [Key]
        public int Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int CodigoCargo { get; set; }

        public virtual Cargo Cargo { get; set; }
    }
}