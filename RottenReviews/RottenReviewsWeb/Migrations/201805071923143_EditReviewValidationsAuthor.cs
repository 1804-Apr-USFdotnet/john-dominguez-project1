namespace RottenReviewsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditReviewValidationsAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("Restaurant.Review", "Author", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Restaurant.Review", "Author");
        }
    }
}
