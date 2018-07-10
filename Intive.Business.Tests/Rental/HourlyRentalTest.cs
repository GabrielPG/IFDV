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
    public class HourlyRentalTest
    {
        [TestMethod]
        public void TestGetPrice()
        {
            var rental = new HourlyRental();
            rental.BeginDate = DateTime.Now;
            rental.EndDate = rental.BeginDate.AddHours(3);
            Assert.AreEqual(rental.GetPrice(), 15m);
        }
    }
}
