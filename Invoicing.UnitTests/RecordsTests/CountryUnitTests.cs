using Invoicing.Core.RecordTypes;
using Invoicing.Core.IRecordTypes;
using Invoicing.Core.Repository;
using Invoicing.Core.Database;
using NSubstitute;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Invoicing.UnitTests.RecordsTests
{
    public class CountryUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountryTest()
        {
            var norway = Substitute.For<ICountry>();

            norway.PercentRateOfVAT.Returns(25m);
            norway.CountryCode.Returns("NO");
            norway.CountryName.Returns("Norway");
            norway.EuropeanUnionMember.Returns(false);

            Assert.AreEqual("NO", norway.CountryCode);
            Assert.AreEqual("Norway", norway.CountryName);
            Assert.AreEqual(false, norway.EuropeanUnionMember);
            Assert.AreEqual(25m, norway.PercentRateOfVAT);
        }

        [Test]
        public void CountryRepositoryInsertTest()
        {
            Repository<Country> countriesRepo = new Repository<Country>(new InvoicesDatabaseContext());
            Assert.AreEqual(0, countriesRepo.GetAll().Count());
            countriesRepo.Insert(new Country("NO", "Norway", 25m));
            countriesRepo.Insert(new Country("PL", "Poland", 23m));
            Assert.AreEqual(2, countriesRepo.GetAll().Count());
        }

    }
}
