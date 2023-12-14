using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Empleado.Models
{
    [Table("Cargos")]
    public class Cargo
    {
        [Key]
        public int CodigoCargo { get; set; }
        public string NombreCargo { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}