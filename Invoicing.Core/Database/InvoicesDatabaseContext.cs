using Invoicing.Core.RecordTypes;
using Microsoft.EntityFrameworkCore;
using System;

namespace Invoicing.Core.Database
{
    /// <summary>
    /// Invoices database context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class InvoicesDatabaseContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesDatabaseContext"/> class.
        /// </summary>
        public InvoicesDatabaseContext() 
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesDatabaseContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public InvoicesDatabaseContext(DbContextOptions<InvoicesDatabaseContext> options) 
            : base(options)
        { 
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>
        /// The invoices.
        /// </value>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Gets or sets the parties.
        /// </summary>
        /// <value>
        /// The parties.
        /// </value>
        public DbSet<Party> Parties { get; set; }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public DbSet<Person> Persons { get; set; }

        #endregion Properties

        #region

        /// <summary>
        /// On configurinf database context
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

    }
}
