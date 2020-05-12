namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
           

            
            AlterColumn("dbo.Mitarbeiter", "Beruf", c => c.String(nullable: false, maxLength: 76,defaultValue:"BLA BLA"));

        }
        
        public override void Down()
        {

        }
    }
}
