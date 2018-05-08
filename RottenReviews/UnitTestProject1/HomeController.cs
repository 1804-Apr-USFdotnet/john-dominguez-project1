using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class HomeController
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act

            // Assert
            Assert.IsNotNull(true);
        }

    }
}
