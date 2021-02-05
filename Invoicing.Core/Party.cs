using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core
{
    /// <summary>
    /// Party side
    /// </summary>
    public abstract class Party : IDataChanges
    {
        public Party(Country country, bool isVATPayer = false)
        {
            this.isVATPayer = isVATPayer;
            this.country = country;
            country.DataChanged += (sender, args) => NotifyThatDataHasChanged(this);
        }

        private bool isVATPayer;
        private Country country;

        /// <summary>
        /// Occurs when [data changed].
        /// </summary>
        public event EventHandler DataChanged;

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
            set { isVATPayer = value; NotifyThatDataHasChanged(); } 
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
            set { country = value; NotifyThatDataHasChanged(); }
        }

        /// <summary>
        /// Notifies the that data has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        public void NotifyThatDataHasChanged(object sender = null)
        {
            if (DataChanged != null)
                DataChanged(sender != null ? sender: this, new EventArgs());
        }
    }
}
