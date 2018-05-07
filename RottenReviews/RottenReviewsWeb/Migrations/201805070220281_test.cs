namespace RottenReviewsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Restaurant.Restaurant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Zipcode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Restaurant.Review",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(maxLength: 400),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Restaurant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Restaurant.Restaurant", t => t.Restaurant_ID)
                .Index(t => t.Restaurant_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Restaurant.Review", "Restaurant_ID", "Restaurant.Restaurant");
            DropIndex("Restaurant.Review", new[] { "Restaurant_ID" });
            DropTable("Restaurant.Review");
            DropTable("Restaurant.Restaurant");
        }
    }
}
