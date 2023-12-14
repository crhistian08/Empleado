namespace Empleado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        CodigoCargo = c.Int(nullable: false, identity: true),
                        NombreCargo = c.String(),
                    })
                .PrimaryKey(t => t.CodigoCargo);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Cedula = c.Int(nullable: false, identity: true),
                        Nombre1 = c.String(),
                        Nombre2 = c.String(),
                        Apellido1 = c.String(),
                        Apellido2 = c.String(),
                        CodigoCargo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cedula)
                .ForeignKey("dbo.Cargos", t => t.CodigoCargo, cascadeDelete: true)
                .Index(t => t.CodigoCargo);
            
            CreateTable(
                "dbo.DatosSalariales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CedulaEmpleado = c.Int(nullable: false),
                        Cedula = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empleados", t => t.Cedula)
                .Index(t => t.Cedula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatosSalariales", "Cedula", "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "CodigoCargo", "dbo.Cargos");
            DropIndex("dbo.DatosSalariales", new[] { "Cedula" });
            DropIndex("dbo.Empleadoes", new[] { "CodigoCargo" });
            DropTable("dbo.DatosSalariales");
            DropTable("dbo.Empleados");
            DropTable("dbo.Cargos");
        }
    }
}
