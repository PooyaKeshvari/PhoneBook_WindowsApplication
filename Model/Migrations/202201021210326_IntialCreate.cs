namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        ContactAddress = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactLists");
        }
    }
}
