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
    public class FamilyRentalTest
    {
        private List<SingleRental> _rentals;
        private DateTime _baseDate = DateTime.Now;

        [TestInitialize]
        public void TestInitialize()
        {
            _rentals = new List<SingleRental>();
            _rentals.Add(new HourlyRental { BeginDate = _baseDate, EndDate = _baseDate.AddHours(3)});
            _rentals.Add(new DailyRental { BeginDate = _baseDate, EndDate = _baseDate.AddDays(3) });
            _rentals.Add(new WeeklyRental { BeginDate = _baseDate, EndDate = _baseDate.AddDays(3 * 7) });
            _baseDate = _baseDate.AddDays(1);
            _rentals.Add(new HourlyRental { BeginDate = _baseDate, EndDate = _baseDate.AddHours(3) });
            _rentals.Add(new DailyRental { BeginDate = _baseDate, EndDate = _baseDate.AddDays(3) });
            _rentals.Add(new WeeklyRental { BeginDate = _baseDate, EndDate = _baseDate.AddDays(3 * 7) });
        }

        [TestMethod]
        public void TestAdd()
        {
            var familyRental = new FamilyRental();
            var rentals = _rentals.Take(3).ToList();

            foreach (var r in rentals) familyRental.AddRental(r);
            Assert.AreEqual(familyRental.Rentals.Count(), 3);

            foreach (var r in familyRental.Rentals) rentals.Remove(r);
            Assert.AreEqual(rentals.Count, 0);
        }

        [TestMethod]
        public void TestRemove()
        {
            var familyRental = new FamilyRental();
            var rentals = _rentals.Take(3).ToList();

            foreach (var r in rentals) familyRental.AddRental(r);
            Assert.AreEqual(familyRental.Rentals.Count(), 3);

            foreach (var r in rentals) familyRental.RemoveRental(r);
            Assert.AreEqual(familyRental.Rentals.Count(), 0);
        }

        [TestMethod]
        public void TestAddExcess()
        {
            var familyRental = new FamilyRental();
            var rentals = _rentals.Take(5).ToList();
            foreach (var r in rentals) familyRental.AddRental(r);
            Assert.ThrowsException<RentalException>(() =>familyRental.AddRental(rentals.Last()));
        }

        [TestMethod]
        public void TestIsValid()
        {
            var familyRental = new FamilyRental();
            var rentals = _rentals.Take(5).ToList();
            foreach (var r in rentals) familyRental.AddRental(r);
            Assert.IsTrue(familyRental.IsValid());
        }

        [TestMethod]
        public void TestIsNotValid()
        {
            var familyRental = new FamilyRental();
            var rentals = _rentals.Take(2).ToList();
            foreach (var r in rentals) familyRental.AddRental(r);
            Assert.IsFalse(familyRental.IsValid());
        }

        [TestMethod]
        public void TestGetPrice()
        {
            var familyRental = new FamilyRental();
            var rentals = _rentals.Take(3).ToList();
            foreach (var r in rentals) familyRental.AddRental(r);
            var expectedPrice = (15m + 60m + 180m);
            expectedPrice -= expectedPrice * 0.3m;
            Assert.AreEqual(familyRental.GetPrice(), expectedPrice);
        }

        [TestMethod]
        public void TestIsFinished()
        {
            var familyRental = new FamilyRental();
            var rentals = _rentals.Take(3).ToList();
            foreach (var r in rentals) familyRental.AddRental(r);
            Assert.IsTrue(familyRental.IsFinished());
        }

        [TestMethod]
        public void TestIsNotFinished()
        {
            var familyRental = new FamilyRental();            
            familyRental.AddRental(new HourlyRental { BeginDate = _baseDate, EndDate = _baseDate.AddHours(3) });
            familyRental.AddRental(new HourlyRental { BeginDate = _baseDate });
            familyRental.AddRental(new HourlyRental { BeginDate = _baseDate, EndDate = _baseDate.AddHours(3) });
            Assert.IsFalse(familyRental.IsFinished());            
        }

        [TestMethod]
        public void TestBeginDate()
        {
            var familyRental = new FamilyRental();
            familyRental.AddRental(new HourlyRental { BeginDate = _baseDate});
            familyRental.AddRental(new HourlyRental { BeginDate = _baseDate.AddDays(-5) });
            Assert.AreEqual(familyRental.BeginDate, _baseDate.AddDays(-5));
        }

        [TestMethod]
        public void TestEndDate()
        {
            var familyRental = new FamilyRental();
            familyRental.AddRental(new HourlyRental { BeginDate = _baseDate, EndDate = _baseDate.AddHours(8) });
            familyRental.AddRental(new HourlyRental { BeginDate = _baseDate, EndDate = _baseDate.AddHours(3) });
            Assert.AreEqual(familyRental.EndDate, _baseDate.AddHours(8));
        }

        [TestMethod]
        public void TestAvailableSlots()
        {
            var familyRental = new FamilyRental();
            Assert.AreEqual(familyRental.AvailableSlots, 5);
            familyRental.AddRental(_rentals[0]);
            Assert.AreEqual(familyRental.AvailableSlots, 4);
        }
    }
}
