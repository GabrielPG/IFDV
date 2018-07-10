using System;
using System.Collections.Generic;
using System.Text;

namespace Intive.Business.Rental
{
    public class RentalException : Exception
    {
        public RentalException(string message) : base(message) { }
    }
}
