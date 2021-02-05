using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core
{
    /// <summary>
    /// Date changes interface
    /// </summary>
    public interface IDataChanges
    {
        /// <summary>
        /// Occurs when [data changed].
        /// </summary>
        event EventHandler DataChanged;

        /// <summary>
        /// Notifies the that data has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        void NotifyThatDataHasChanged(object sender = null);

    }
}
