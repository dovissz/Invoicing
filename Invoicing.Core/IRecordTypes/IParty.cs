using System;
using System.Collections.Generic;
using System.Text;
using Invoicing.Core.RecordTypes;

namespace Invoicing.Core.IRecordTypes
{
    /// <summary>
    /// Party interface
    /// </summary>
    public interface IParty
    {

        #region Properties

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is vat payer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is vat payer; otherwise, <c>false</c>.
        /// </value>
        public bool IsVATPayer { get; set; }


        public Country Country { get; set; }

        #endregion Properties

    }
}
