using System;
using System.Collections.Generic;
using System.Text;

namespace Invoicing.Core.Repository
{
    /// <summary>
    /// Base entity class
    /// </summary>
    /// <seealso cref="Invoicing.Core.Repository.IEntity" />
    public class BaseEntity : IEntity
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        #endregion Constructors

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
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        #endregion Properties
    }
}
