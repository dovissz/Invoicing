using Invoicing.Core.RecordTypes;
using Invoicing.Core.IRecordTypes;
using NSubstitute;
using NUnit.Framework;
using Invoicing.Core.Repository;
using Invoicing.Core.Database;
using System.Linq;

namespace Invoicing.UnitTests.RecordsTests
{
    public class CompanyUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CompanyTest()
        {
            var poland = Substitute.For<Country>("PL", "Poland", 23m, true);
            var company = Substitute.For<ICompany>();

            company.Country.Returns(poland);
            company.Title.Returns("Small company");
            company.IsVATPayer.Returns(true);

            Assert.AreEqual("Small company", company.Title);
            Assert.AreEqual("PL", company.Country.CountryCode);
        }

        [Test]
        public void CompanyRepositoryGetByIdTest()
        {
            Repository<Company> companiesRepo = new Repository<Company>(new InvoicesDatabaseContext());
            var norway = new Country("NO", "Norway", 25m);
            var smallCompany = new Company("Small company", norway, false);
            companiesRepo.Insert(smallCompany);
            Assert.AreEqual(smallCompany, companiesRepo.GetById(smallCompany.Id));
        }

    }
}
