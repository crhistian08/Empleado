using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Empleado.Models
{
    public class ApplicationDbContext : DbContext
    {
    

        public ApplicationDbContext() : base("connDB0")
        {
        }

        public DbSet<Empleados> Empleado { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<DatosSalariales> DatosSalariales { get; set; }
    }
}