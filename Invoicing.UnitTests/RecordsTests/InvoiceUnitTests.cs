using Invoicing.Core.RecordTypes;
using Invoicing.Core.IRecordTypes;
using NSubstitute;
using NUnit.Framework;
using Invoicing.Core.Repository;
using Invoicing.Core.Database;
using System.Linq;

namespace Invoicing.UnitTests.RecordsTests
{
    public class InvoiceUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InvoiceInsideSameCountryTest()
        {
            var lithuania = Substitute.For<Country>("LT", "Lithuania", 21m, true);
            var sender = Substitute.For<Company>("Awesome company", lithuania, true);
            var reciever = Substitute.For<Person>("Dovydas", "Krakauskas", lithuania, false);
            var invoice = Substitute.For<Invoice>(sender, reciever, 200m);

            Assert.AreEqual(0, invoice.TaxesSum);
            Assert.AreEqual(200, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(0, invoice.TotalOrderSum);

            Assert.That(invoice.CalculateTotal(), Is.EqualTo(242));

            Assert.AreEqual(42, invoice.TaxesSum);
            Assert.AreEqual(200, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(242, invoice.TotalOrderSum);
        }

        [Test]
        public void InvoiceInDifferentEUCountriesWhileRecieverIsNotVATPayerTest()
        {
            var lithuania = Substitute.For<Country>("LT", "Lithuania", 21m, true);
            var poland = Substitute.For<Country>("PL", "Poland", 23m, true);
            var sender = Substitute.For<Company>("Awesome company", lithuania, true);
            var reciever = Substitute.For<Person>("Dovydas", "Krakauskas", poland, false);
            var invoice = Substitute.For<Invoice>(sender, reciever, 100m);

            Assert.AreEqual(0, invoice.TaxesSum);
            Assert.AreEqual(100, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(0, invoice.TotalOrderSum);

            Assert.That(invoice.CalculateTotal(), Is.EqualTo(123));

            Assert.AreEqual(23, invoice.TaxesSum);
            Assert.AreEqual(100, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(123, invoice.TotalOrderSum);
        }

        [Test]
        public void InvoiceOutsideEUTest()
        {
            var lithuania = Substitute.For<Country>("LT", "Lithuania", 21m, true);
            var norway = Substitute.For<Country>("NO", "Norway", 25m, false);
            var sender = Substitute.For<Company>("Awesome company", lithuania, true);
            var reciever = Substitute.For<Person>("Dovydas", "Krakauskas", norway, false);
            var invoice = Substitute.For<Invoice>(sender, reciever, 565m);

            Assert.AreEqual(0, invoice.TaxesSum);
            Assert.AreEqual(565, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(0, invoice.TotalOrderSum);

            Assert.That(invoice.CalculateTotal(), Is.EqualTo(565));

            Assert.AreEqual(0, invoice.TaxesSum);
            Assert.AreEqual(565, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(565, invoice.TotalOrderSum);
        }

        [Test]
        public void InvoiceWhenCountryWasAcceptedIntoEUTest()
        {
            var lithuania = Substitute.For<Country>("LT", "Lithuania", 21m, true);
            var norway = Substitute.For<Country>("NO", "Norway", 25m, false);
            var sender = Substitute.For<Company>("Awesome company", lithuania, true);
            var reciever = Substitute.For<Person>("Dovydas", "Krakauskas", norway, false);
            var invoice = Substitute.For<Invoice>(sender, reciever, 565m);

            Assert.That(invoice.CalculateTotal(), Is.EqualTo(565));
            norway.EuropeanUnionMember = true;
            Assert.That(invoice.CalculateTotal(), Is.EqualTo(706.25));
        }

        [Test]
        public void InvoiceRepositoryUpdateTest()
        {
            Repository<Invoice> invoicesRepo = new Repository<Invoice>(new InvoicesDatabaseContext());
            var england = new Country("GB", "Great Britan", 27m);
            var receiver = new Person("Dovydas", "Krakauskas", england, false);
            var sender = new Company("Small company", england, true);
            var invoice = new Invoice(sender, receiver, 350);

            invoicesRepo.Insert(invoice);
            Assert.AreEqual(350, invoicesRepo.GetAll().FirstOrDefault().SumOfOrderBeforeTaxes);
            invoice.SumOfOrderBeforeTaxes = 666;
            invoicesRepo.Update(invoice);
            Assert.AreEqual(666, invoicesRepo.GetAll().FirstOrDefault().SumOfOrderBeforeTaxes);
        }

    }
}
