using System;
using System.Collections.Generic;
using System.Text;
using Invoicing.Core.IRecordTypes;
using Invoicing.Core.Repository;

namespace Invoicing.Core.RecordTypes
{
    /// <summary>
    /// Party side
    /// </summary>
    public abstract class Party : BaseEntity, IParty
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Party"/> class.
        /// </summary>
        public Party()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Party"/> class.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="isVATPayer">if set to <c>true</c> [is vat payer].</param>
        public Party(Country country, bool isVATPayer = false)
        {
            this.isVATPayer = isVATPayer;
            this.country = country;
        }

        #endregion Constructors

        #region Properties

        private bool isVATPayer;
        private Country country;

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public abstract string Title { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is vat payer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is vat payer; otherwise, <c>false</c>.
        /// </value>
        public bool IsVATPayer 
        { 
            get => isVATPayer;
            set => isVATPayer = value;
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public Country Country 
        {
            get => country;
            set => country = value;
        }

        #endregion Properties

    }
}
