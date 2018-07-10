using Intive.Business.Rental;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveBusiness.Tests
{
    [TestClass]
    public class WeeklyRentalTest
    {
        [TestMethod]
        public void TestGetPrice()
        {
            var rental = new WeeklyRental();
            rental.BeginDate = DateTime.Now;
            rental.EndDate = rental.BeginDate.AddDays(21);
            Assert.AreEqual(rental.GetPrice(), 180m);
        }
    }
}
