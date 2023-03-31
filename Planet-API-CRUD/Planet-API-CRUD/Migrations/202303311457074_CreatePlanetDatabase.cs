namespace Planet_API_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePlanetDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(),
                        Moons = c.Int(nullable: false),
                        DistanceFromSun = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Planets");
        }
    }
}
