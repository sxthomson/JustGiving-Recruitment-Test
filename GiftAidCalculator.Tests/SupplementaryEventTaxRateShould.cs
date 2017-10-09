namespace GiftAidCalculator.Tests
{
    using TestConsole;
    using TestConsole.Models;
    using NUnit.Framework;

    [TestFixture]
    public class SupplementaryEventTaxRateShould
    {
        [TestCase("5", FundraisingEventType.Running)]
        [TestCase("3", FundraisingEventType.Swimming)]
        [TestCase("0", FundraisingEventType.Cycling)]
        public void Be_The_Following_Rate_For_The_Given_Fundraising_Event_Type(string expectedTaxRateString, FundraisingEventType eventType)
        {
            // Arrange
            var expectedTaxRate = decimal.Parse(expectedTaxRateString);
            
            var supplementaryEventTaxRateRepository = new InMemorySupplementaryEventTaxRateRepository();

            // Act
            var actualTaxRate = supplementaryEventTaxRateRepository.GetTaxRate(eventType);

            // Assert
            Assert.That(actualTaxRate, Is.EqualTo(expectedTaxRate));
        }
    }
}