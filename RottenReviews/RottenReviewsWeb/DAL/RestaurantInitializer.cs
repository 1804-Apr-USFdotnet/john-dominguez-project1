using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RottenReviewsWeb.Models;

namespace RottenReviewsWeb.DAL
{
    public class RestaurantInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RestaurantContext>
    {
        protected override void Seed(RestaurantContext context)
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "The Refinery",
                    Street = "5910 N Florida Ave",
                    City = "Tampa",
                    State = "FL",
                    Zipcode = "33604",
                    Country = "US",
                    Phone = "(813) 234-3710",
                    Email = "",
                    Website = "places.singleplatform.com"
                },
                new Restaurant
                {
                    Name = "Ulele",
                    Street = "1810 N Highland Ave",
                    City = "Tampa",
                    State = "FL",
                    Zipcode = "33602",
                    Country = "US",
                    Phone = "(813) 999-4952",
                    Email = "",
                    Website = "ulele.com"
                },
                new Restaurant
                {
                    Name = "Mise en Place",
                    Street = "442 W Kennedy Blvd #110",
                    City = "Tampa",
                    State = "FL",
                    Zipcode = "33606",
                    Country = "US",
                    Phone = "(813) 254-5373",
                    Email = "",
                    Website = "miseonline.com"
                },
                new Restaurant
                {
                    Name = "Oxford Exchange",
                    Street = "420 W Kennedy Blvd",
                    City = "Tampa",
                    State = "FL",
                    Zipcode = "33602",
                    Country = "US",
                    Phone = "(813) 253-0222",
                    Email = "",
                    Website = "oxfordexchange.com"
                }
            };

            restaurants.ForEach(r => context.Restaurants.Add(r));
            context.SaveChanges();
            
        }
    }
}