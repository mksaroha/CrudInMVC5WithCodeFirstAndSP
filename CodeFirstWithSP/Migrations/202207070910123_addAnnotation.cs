namespace CodeFirstWithSP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "City", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
