using System;
using System.Collections.Generic;
using System.Text;

namespace Intive.Business.Rental
{
    /// <summary>
    /// IRental interface, represents a bike rental
    /// </summary>
    public interface IRental
    {
        /// <summary>
        /// Rental Begin Date
        /// </summary>
        DateTime BeginDate { get; }

        /// <summary>
        /// Rental End Date
        /// </summary>
        DateTime EndDate { get; }

        /// <summary>
        /// Get the final amount to charge for the rental (Rental has ended)
        /// </summary>
        /// <returns></returns>
        decimal GetPrice();

        /// <summary>
        /// Is rental finished?
        /// </summary>
        /// <returns></returns>
        bool IsFinished();
    }
}
