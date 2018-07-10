using System;
using Intive.Business.Rental;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntiveBusiness.Tests
{
    [TestClass]
    public class DailyRentalTest
    {
        [TestMethod]
        public void TestGetPrice()
        {
            var rental = new DailyRental();
            rental.BeginDate = DateTime.Now;
            rental.EndDate = rental.BeginDate.AddDays(3);
            Assert.AreEqual(rental.GetPrice(), 60m);
        }
    }
}
