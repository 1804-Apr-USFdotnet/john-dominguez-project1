namespace RottenReviewsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeToNullable : DbMigration
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
                        Zipcode = c.String(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Created = c.DateTime(),
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
                        Author = c.String(nullable: false),
                        RestaurantID = c.Int(nullable: false),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Restaurant.Restaurant", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Restaurant.Review", "RestaurantID", "Restaurant.Restaurant");
            DropIndex("Restaurant.Review", new[] { "RestaurantID" });
            DropTable("Restaurant.Review");
            DropTable("Restaurant.Restaurant");
        }
    }
}
