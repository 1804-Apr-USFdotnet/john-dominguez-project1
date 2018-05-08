using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RottenReviewsLibrary;
using RottenReviewsWeb.Controllers;
using RottenReviewsWeb.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class RestaurantTests
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new RestaurantsController();
            var result = controller.Details(1) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestTopRestaurant()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Loving Hut",
                    Street = "320 Bayan Circle USF",
                    City = "Tampa",
                    State = "FL",
                    Country = "US",
                    Zipcode = "34510"
                }
            };
            var list = Sorting.SortDescending(restaurants, "Rating");
            var topRestaurant = Sorting.Top(list, 1);

            Assert.AreEqual(restaurants[0].Name,topRestaurant[0].Name);
        }

        [TestMethod]
        public void TestTopRestaurantNull()
        {
            var restaurants = new List<Restaurant>
            {
            };
            var list = Sorting.SortDescending(restaurants, "Rating");
            var topRestaurant = Sorting.Top(list, 1);

            Assert.AreEqual(0, topRestaurant.Count);
        }


    }
}
