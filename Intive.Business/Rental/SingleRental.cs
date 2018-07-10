using System;
using System.Collections.Generic;
using System.Text;

namespace Intive.Business.Rental
{
    public abstract class SingleRental : IRental
    {
        private DateTime _beginDate;
        private DateTime _endDate = DateTime.MaxValue;

        public DateTime BeginDate
        {
            get
            {
                return _beginDate;
            }
            set
            {
                if (value >= _endDate) throw new RentalException("Invalid begin date");
                _beginDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (value <= _beginDate) throw new RentalException("Invalid end date");
                _endDate = value;
            }
        }

        public bool IsFinished()
        {
            return _endDate != DateTime.MaxValue;
        }

        public decimal GetPrice()
        {
            if (!IsFinished()) throw new RentalException("Rental is not finished");
            return GetPrice(_endDate - _beginDate);
        }

        protected abstract decimal GetPrice(TimeSpan timeSpan);
    }
}
