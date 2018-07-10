using System;
using System.Collections.Generic;
using System.Text;

namespace Intive.Business.Rental
{
    public class WeeklyRental : SingleRental
    {
        protected override decimal GetPrice(TimeSpan spannedTime)
        {
            return (int)Math.Ceiling(spannedTime.TotalDays) / 7 * 60m;
        }
    }
}
