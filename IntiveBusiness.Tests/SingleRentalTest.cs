using Intive.Business.Rental;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiveBusiness.Tests
{
    [TestClass]
    public class SingleRentalTest
    {
        [TestMethod]
        public void TestIsFinished()
        {
            var mockRental = new Mock<SingleRental>();
            mockRental.Object.BeginDate = DateTime.Now;
            mockRental.Object.EndDate = mockRental.Object.BeginDate.AddDays(3);
            Assert.IsTrue(mockRental.Object.IsFinished());
        }

        [TestMethod]
        public void TestIsNotFinished()
        {
            var mockRental = new Mock<SingleRental>();
            mockRental.Object.BeginDate = DateTime.Now;
            Assert.IsFalse(mockRental.Object.IsFinished());
        }

        [TestMethod]
        public void TestBadBeginDate()
        {
            var mockRental = new Mock<SingleRental>();
            mockRental.Object.EndDate = DateTime.Now;
            Assert.ThrowsException<RentalException>(() => mockRental.Object.BeginDate = mockRental.Object.EndDate.AddDays(3));
        }

        [TestMethod]
        public void TestBadEndDate()
        {
            var mockRental = new Mock<SingleRental>();
            mockRental.Object.BeginDate = DateTime.Now;
            Assert.ThrowsException<RentalException>(() => mockRental.Object.EndDate = mockRental.Object.BeginDate.AddDays(-3));
        }


        [TestMethod]
        public void TestGetPrice()
        {
            var mockRental = new Mock<SingleRental>();
            mockRental.Object.BeginDate = DateTime.Now;
            mockRental.Object.EndDate = mockRental.Object.BeginDate.AddDays(3);
            mockRental.Object.GetPrice();
            mockRental.Protected().Verify("GetPrice", Times.Once(), mockRental.Object.EndDate - mockRental.Object.BeginDate);
        }
    }
}
