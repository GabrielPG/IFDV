using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace Intive.Business.Rental
{
    public class FamilyRental : IRental
    {
        private const int MinRentals = 3;
        private const int MaxRentals = 5;

        private IList<SingleRental> _rentals = new List<SingleRental>();

        public void AddRental(SingleRental rental)
        {
            Debug.Assert(rental != null);
            if (_rentals.Count == MaxRentals) throw new RentalException("Max number of rentals reached");
            if (_rentals.Contains(rental)) throw new RentalException("Rental has already been added");
            _rentals.Add(rental);
        }

        public void RemoveRental(SingleRental rental)
        {
            Debug.Assert(rental != null);
            var removed = _rentals.Remove(rental);
            if(!removed) throw new RentalException("Rental not found");
        }

        public IEnumerable<SingleRental> Rentals
        {
            get
            {
                return _rentals;
            }
        }

        public int AvailableSlots
        {
            get
            {
                return MaxRentals - _rentals.Count;
            }
        }

        public bool IsValid()
        {
            return (_rentals.Count >= MinRentals) && (_rentals.Count <= MaxRentals);
        }

        public DateTime BeginDate
        {
            get
            {
                return _rentals.Min(r => r.BeginDate);
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _rentals.Max(r => r.EndDate);
            }
        }

        public bool IsFinished()
        {
            return _rentals.All(r => r.IsFinished());
        }

        public decimal GetPrice()
        {
            if(!IsValid()) throw new RentalException("Family rental is not valid");
            var price = _rentals.Sum(rental => rental.GetPrice());
            return price - (price * 0.3m);
        }
    }
}
