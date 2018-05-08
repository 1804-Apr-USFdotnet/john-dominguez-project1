using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RottenReviewsWeb.Controllers;

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
    }
}
