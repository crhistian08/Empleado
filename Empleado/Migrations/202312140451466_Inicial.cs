namespace Empleado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        CodigoCargo = c.Int(nullable: false, identity: true),
                        NombreCargo = c.String(),
                    })
                .PrimaryKey(t => t.CodigoCargo);
            
            CreateTable(
                "dbo.Empleadoes",
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
                .ForeignKey("dbo.Cargoes", t => t.CodigoCargo, cascadeDelete: true)
                .Index(t => t.CodigoCargo);
            
            CreateTable(
                "dbo.DatosSalariales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CedulaEmpleado = c.Int(nullable: false),
                        Empleado_Cedula = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_Cedula)
                .Index(t => t.Empleado_Cedula);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatosSalariales", "Empleado_Cedula", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "CodigoCargo", "dbo.Cargoes");
            DropIndex("dbo.DatosSalariales", new[] { "Empleado_Cedula" });
            DropIndex("dbo.Empleadoes", new[] { "CodigoCargo" });
            DropTable("dbo.DatosSalariales");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Cargoes");
        }
    }
}
