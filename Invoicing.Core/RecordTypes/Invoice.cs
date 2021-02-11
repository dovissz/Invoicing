using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Core.IRecordTypes;
using Invoicing.Core.Repository;

namespace Invoicing.Core.RecordTypes
{
    /// <summary>
    /// Represents invoice with all its information
    /// </summary>
    public class Invoice : BaseEntity, IInvoice
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        public Invoice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="reciever">The reciever.</param>
        /// <param name="sumOfOrderBeforeTaxes">The sum of order before taxes.</param>
        public Invoice(Company sender, Party reciever, decimal sumOfOrderBeforeTaxes)
        {
            this.sender = sender;
            this.reciever = reciever;
            this.sumOfOrderBeforeTaxes = sumOfOrderBeforeTaxes;
        }

        #endregion Constructors

        #region Properties

        private Company sender;
        private Party reciever;
        private decimal sumOfOrderBeforeTaxes;
        private decimal taxesSum;
        private decimal totalOrderSum;

        /// <summary>
        /// Gets or sets the sum of order before taxes.
        /// </summary>
        /// <value>
        /// The sum of order before taxes.
        /// </value>
        public decimal SumOfOrderBeforeTaxes
        {
            get => sumOfOrderBeforeTaxes;
            set => sumOfOrderBeforeTaxes = value;
        }

        /// <summary>
        /// Gets the taxes sum.
        /// </summary>
        /// <value>
        /// The taxes sum.
        /// </value>
        public decimal TaxesSum => taxesSum;

        /// <summary>
        /// Gets the total order sum.
        /// </summary>
        /// <value>
        /// The total order sum.
        /// </value>
        public decimal TotalOrderSum => totalOrderSum;

        /// <summary>
        /// Gets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        public Company Sender => sender;

        /// <summary>
        /// Gets the reciever.
        /// </summary>
        /// <value>
        /// The reciever.
        /// </value>
        public Party Reciever => reciever;

        #endregion Properties

        #region Methods

        private decimal CalculateVatRatio()
        {
            if (sender.IsVATPayer)
            {
                if (sender.Country.CountryCode == reciever.Country.CountryCode)
                    return reciever.Country.PercentRateOfVAT;
                else if (reciever.Country.EuropeanUnionMember && !reciever.IsVATPayer)
                    return reciever.Country.PercentRateOfVAT;
            }
            return 0;
        }

        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotal()
        {
            taxesSum = (CalculateVatRatio() * sumOfOrderBeforeTaxes) / 100;
            totalOrderSum = taxesSum + sumOfOrderBeforeTaxes;
            return totalOrderSum;
        }

        #endregion Methods

    }
}
