using System;
using System.Collections.Generic;
using System.Text;
using Invoicing.Core.IRecordTypes;

namespace Invoicing.Core.RecordTypes
{
    /// <summary>
    /// Person class represents physical person
    /// </summary>
    public class Person : Party, IPerson
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="surname">The surname.</param>
        /// <param name="country">The country.</param>
        /// <param name="isVATPayer">if set to <c>true</c> [is vat payer].</param>
        public Person(string name, string surname, Country country, bool isVATPayer = false) 
            : base(country, isVATPayer)
        {
            this.name = name;
            this.surname = surname;
        }

        #endregion Constructors

        #region Properties

        private string name;
        private string surname;

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public override string Title => string.Format("{0} {1}", name, surname);

        #endregion Properties

    }
}
