using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core
{
    /// <summary>
    /// Represents invoice with all its information
    /// </summary>
    public class Invoice
    {
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
            sender.DataChanged += (sender, args) => CalculateTotal();
            reciever.DataChanged += (sender, args) => CalculateTotal();
            CalculateTotal();
        }

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
            set { sumOfOrderBeforeTaxes = value; CalculateTotal(); }
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

        private void CalculateTotal()
        {
            taxesSum = (CalculateVatRatio() * sumOfOrderBeforeTaxes) / 100;
            totalOrderSum = taxesSum + sumOfOrderBeforeTaxes;
        }

    }
}
