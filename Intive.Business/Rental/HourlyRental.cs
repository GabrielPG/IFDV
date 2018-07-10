using System;
using System.Collections.Generic;
using System.Text;

namespace Intive.Business.Rental
{
    public class HourlyRental : SingleRental
    {
        protected override decimal GetPrice(TimeSpan spannedTime)
        {
            return (int)Math.Ceiling(spannedTime.TotalHours) * 5m;
        }
    }
}
