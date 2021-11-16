namespace Case_study.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flight",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        source = c.String(),
                        destination = c.String(),
                        Airplane = c.String(),
                        departure = c.DateTime(nullable: false),
                        type = c.String(),
                        price = c.Int(nullable: false),
                        Araival = c.String(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Flight");
        }
    }
}
