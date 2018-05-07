namespace RottenReviewsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRestaurantValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Restaurant.Restaurant", "Zipcode", c => c.String(nullable: false));
            AlterColumn("Restaurant.Restaurant", "Phone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Restaurant.Restaurant", "Phone", c => c.String());
            AlterColumn("Restaurant.Restaurant", "Zipcode", c => c.String());
        }
    }
}
