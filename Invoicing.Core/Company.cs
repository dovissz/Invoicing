using System;

namespace Invoicing.Core
{
    /// <summary>
    /// Company class represents juridical person
    /// </summary>
    public class Company : Party
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="companyTitle">The company title.</param>
        /// <param name="country">The country.</param>
        /// <param name="isVATPayer">if set to <c>true</c> [is vat payer].</param>
        public Company(string companyTitle, Country country, bool isVATPayer = false) : base(country, isVATPayer)
        {
            this.companyTitle = companyTitle;
        }

        private string companyTitle;

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public override string Title => companyTitle;

    }
}
