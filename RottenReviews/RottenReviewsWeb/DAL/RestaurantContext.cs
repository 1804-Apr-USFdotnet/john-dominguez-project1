using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using RottenReviewsWeb.Models;

namespace RottenReviewsWeb.DAL
{
    public class RestaurantContext : DbContext, IDbContext
    {
        public RestaurantContext() : base("RestaurantContext")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("Created").CurrentValue = DateTime.Now;
            });

            var ModifiedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            ModifiedEntities.ForEach(E =>
            {
                E.Property("Modified").CurrentValue = DateTime.Now;
            });
            return base.SaveChanges();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

//        static void Main(string[] args)
//        {
//            Restaurant restaurant = new Restaurant
//            {
//                Name = "The Refinery",
//                Street = "5910 N Florida Ave",
//                City = "Tampa",
//                State = "FL",
//                Zipcode = "33604",
//                Country = "US",
//                Phone = "813-234-3710",
//                Email = "test@test.com",
//                Website = "http://www.places.singleplatform.com"
//            };
//            RestaurantContext db = new RestaurantContext();
//            db.Restaurants.Add(restaurant);
//            db.SaveChanges();
//        }
    }
}