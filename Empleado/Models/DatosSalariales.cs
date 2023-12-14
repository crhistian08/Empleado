using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Empleado.Models
{
    public class DatosSalariales
    {
        [Key]
        public int ID { get; set; }
        public int CedulaEmpleado { get; set; }

        // Agrega las propiedades de datos salariales necesarias

        //public virtual Empleados Empleado { get; set; }
    }
}