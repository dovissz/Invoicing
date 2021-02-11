using Invoicing.Core.RecordTypes;
using Invoicing.Core.IRecordTypes;
using NSubstitute;
using NUnit.Framework;
using Invoicing.Core.Repository;
using Invoicing.Core.Database;
using System.Linq;

namespace Invoicing.UnitTests.RecordsTests
{
    public class PersonUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PersonTest()
        {
            var lithuania = Substitute.For<Country>("LT", "Lithuania", 21m, true);
            var person = Substitute.For<IPerson>();

            person.Country.Returns(lithuania);
            person.Title.Returns("Dovydas Krakauskas");
            person.IsVATPayer.Returns(true);

            Assert.AreEqual("Dovydas Krakauskas", person.Title);
            Assert.AreEqual("LT", person.Country.CountryCode);
        }

        [Test]
        public void PersonRepositoryDeleteTest()
        {
            Repository<Person> personsRepo = new Repository<Person>(new InvoicesDatabaseContext());
            var england = new Country("GB", "Great Britan", 27m);
            var dovydas = new Person("Dovydas", "Krakauskas", england, false);
            personsRepo.Insert(dovydas);
            Assert.AreEqual(1, personsRepo.GetAll().Count());
            personsRepo.Delete(dovydas.Id);
            Assert.AreEqual(0, personsRepo.GetAll().Count());
        }

    }
}
