using System;
using System.Collections.Generic;
using System.Text;

namespace Intive.Business.Rental
{
    public class DailyRental : SingleRental
    {
        protected override decimal GetPrice(TimeSpan spannedTime)
        {
            return (int)Math.Ceiling(spannedTime.TotalDays) * 20m;
        }
    }
}
