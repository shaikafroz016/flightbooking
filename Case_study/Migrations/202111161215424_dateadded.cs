namespace Case_study.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flight", "date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flight", "date");
        }
    }
}
