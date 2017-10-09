namespace GiftAidCalculator.Tests
{
    using GiftAidCalculator.TestConsole;
    using NUnit.Framework;

    [TestFixture]
    public class TaxRateShould
    {
        [Test]
        public void Be_Configurable_For_A_Site_Administrator_So_The_Tax_Rate_Can_Be_Updated_Without_Any_Code_Changes()
        {
            // Arrange
            const decimal originalTaxRate = 20;
            const decimal expectedTaxRate = 60;            
            var taxRateRepository = new InMemoryTaxRateRepository(originalTaxRate);

            // Act
            taxRateRepository.SetTaxRate(expectedTaxRate);
            var actualTaxRate = taxRateRepository.GetTaxRate();
            
            // Assert
            Assert.That(actualTaxRate, Is.EqualTo(expectedTaxRate));
        }
    }
}
