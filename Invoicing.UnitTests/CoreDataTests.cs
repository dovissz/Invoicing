using Invoicing.Core;
using NSubstitute;
using NUnit.Framework;


namespace Invoicing.UnitTests
{
    public class CoreDataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountryTest()
        {
            var norway = Substitute.For<Country>("NO", "Norway", 25m, false);
            Assert.AreEqual("NO", norway.CountryCode);
            Assert.AreEqual("Norway", norway.CountryName);
            Assert.AreEqual(false, norway.EuropeanUnionMember);
            Assert.AreEqual(25m, norway.PercentRateOfVAT);

            bool dataHasBeenChanged = false;
            norway.DataChanged += (sender, args) => dataHasBeenChanged = true;
            norway.EuropeanUnionMember = true;
            Assert.AreEqual(true, dataHasBeenChanged);
            dataHasBeenChanged = false;
            norway.PercentRateOfVAT = 18;
            Assert.AreEqual(true, dataHasBeenChanged);
        }

        [Test]
        public void PersonTest()
        {
            var lithuania = new Country("LT", "Lithuania", 21m, true);
            var person = new Person("Dovydas", "Krakauskas", lithuania, false);
            Assert.AreEqual("Dovydas Krakauskas", person.Title);
            Assert.AreEqual(false, person.IsVATPayer);

            bool dataHasBeenChanged = false;
            person.DataChanged += (sender, args) => dataHasBeenChanged = true;
            person.IsVATPayer = true;
            Assert.AreEqual(true, dataHasBeenChanged);
        }

        [Test]
        public void CompanyTest()
        {
            var poland = new Country("PL", "Poland", 23m, true);
            var company = new Company("Small company", poland, true);
            Assert.AreEqual("Small company", company.Title);
            Assert.AreEqual(true, company.IsVATPayer);

            bool dataHasBeenChanged = false;
            company.DataChanged += (sender, args) => dataHasBeenChanged = true;
            company.IsVATPayer = false;
            Assert.AreEqual(true, dataHasBeenChanged);
        }

        [Test]
        public void InvoiceTest()
        {
            var norway = Substitute.For<Country>("NO", "Norway", 25m, false);
            var lithuania = Substitute.For<Country>("LT", "Lithuania", 21m, true);
            var poland = Substitute.For<Country>("PL", "Poland", 23m, true);
            var sender = Substitute.For<Company>("Awesome company", poland, true);
            var reciever = Substitute.For<Person>("Dovydas", "Krakauskas", lithuania, false);
            var invoice = Substitute.For<Invoice>(sender, reciever, 200m);

            Assert.AreEqual(42, invoice.TaxesSum);
            Assert.AreEqual(200, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(242, invoice.TotalOrderSum);

            lithuania.PercentRateOfVAT = 22m;
            Assert.AreEqual(44, invoice.TaxesSum);
            Assert.AreEqual(200, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(244, invoice.TotalOrderSum);

            reciever.Country = norway;
            Assert.AreEqual(0, invoice.TaxesSum);
            Assert.AreEqual(200, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(200, invoice.TotalOrderSum);

            sender.Country = norway;
            invoice.SumOfOrderBeforeTaxes = 400;
            Assert.AreEqual(100, invoice.TaxesSum);
            Assert.AreEqual(400, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(500, invoice.TotalOrderSum);

            sender.IsVATPayer = false;
            Assert.AreEqual(0, invoice.TaxesSum);
            Assert.AreEqual(400, invoice.SumOfOrderBeforeTaxes);
            Assert.AreEqual(400, invoice.TotalOrderSum);

        }
    }
}