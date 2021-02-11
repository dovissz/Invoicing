using Invoicing.Core.Repository;
using Invoicing.Core.IRecordTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.RecordTypes
{
    /// <summary>
    /// Represents country
    /// </summary>
    public class Country : BaseEntity, ICountry
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class.
        /// </summary>
        public Country()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryName">Name of the country.</param>
        /// <param name="percentRateOfVAT">The rate of vat in percent.</param>
        /// <param name="europeanUnionMember">if set to <c>true</c> [european union member].</param>
        public Country(string countryCode, string countryName, decimal percentRateOfVAT = 0, bool europeanUnionMember = false)
        {
            this.countryCode = countryCode;
            this.countryName = countryName;
            this.percentRateOfVAT = percentRateOfVAT;
            this.europeanUnionMember = europeanUnionMember;
        }

        #endregion Constructors

        #region Properties

        private string countryCode;
        private string countryName;
        private bool europeanUnionMember;
        private decimal percentRateOfVAT;

        /// <summary>
        /// Gets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        public string CountryCode
        {
            get => countryCode;
            set => countryCode = value;
        }

        /// <summary>
        /// Gets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public string CountryName
        {
            get => countryName;
            set => countryName = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [european union member].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [european union member]; otherwise, <c>false</c>.
        /// </value>
        public bool EuropeanUnionMember 
        {
            get => europeanUnionMember;
            set => europeanUnionMember = value;
        }

        /// <summary>
        /// Gets or sets the percent rate of vat.
        /// </summary>
        /// <value>
        /// The percent rate of vat.
        /// </value>
        public decimal PercentRateOfVAT 
        { 
            get => percentRateOfVAT;
            set => percentRateOfVAT = value;
        }

        #endregion Properties

    }
}
