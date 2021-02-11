using System;

namespace Invoicing.Core.RecordTypes
{
    /// <summary>
    /// Company class represents juridical person
    /// </summary>
    public class Company : Party
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="companyTitle">The company title.</param>
        /// <param name="country">The country.</param>
        /// <param name="isVATPayer">if set to <c>true</c> [is vat payer].</param>
        public Company(string companyTitle, Country country, bool isVATPayer = false) 
            : base(country, isVATPayer)
        {
            this.companyTitle = companyTitle;
        }

        #endregion Constructors

        #region Properties

        private string companyTitle;
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public override string Title => companyTitle;

        #endregion Properties

    }
}
