using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.Repository
{
    /// <summary>
    /// Entity interface
    /// </summary>
    public interface IEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}
