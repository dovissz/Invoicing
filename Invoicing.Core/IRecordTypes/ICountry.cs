using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.IRecordTypes
{
    /// <summary>
    /// Contries interface
    /// </summary>
    public interface ICountry
    {

        #region Properties

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        string CountryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [european union member].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [european union member]; otherwise, <c>false</c>.
        /// </value>
        bool EuropeanUnionMember { get; set; }

        /// <summary>
        /// Gets or sets the percent rate of vat.
        /// </summary>
        /// <value>
        /// The percent rate of vat.
        /// </value>
        decimal PercentRateOfVAT { get; set; }

        #endregion Properties

    }
}
