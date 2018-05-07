namespace RottenReviewsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRestaurantValidationsZipcode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Restaurant.Restaurant", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("Restaurant.Restaurant", "Phone", c => c.String(nullable: false));
        }
    }
}
