using System;
using System.Collections.Generic;
using System.Text;
using Invoicing.Core.RecordTypes;

namespace Invoicing.Core.IRecordTypes
{
    /// <summary>
    /// Invoices interfaces
    /// </summary>
    public interface IInvoice
    {

        #region Properties

        /// <summary>
        /// Gets or sets the sum of order before taxes.
        /// </summary>
        /// <value>
        /// The sum of order before taxes.
        /// </value>
        public decimal SumOfOrderBeforeTaxes { get; set; }

        /// <summary>
        /// Gets the taxes sum.
        /// </summary>
        /// <value>
        /// The taxes sum.
        /// </value>
        decimal TaxesSum { get; }

        /// <summary>
        /// Gets the total order sum.
        /// </summary>
        /// <value>
        /// The total order sum.
        /// </value>
        decimal TotalOrderSum { get; }

        /// <summary>
        /// Gets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        Company Sender { get; }

        /// <summary>
        /// Gets the reciever.
        /// </summary>
        /// <value>
        /// The reciever.
        /// </value>
        Party Reciever { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Calculates the total.
        /// </summary>
        /// <returns></returns>
        decimal CalculateTotal();

        #endregion Methods

    }
}
