namespace GiftAidCalculator.Tests
{
    using Moq;
    using NUnit.Framework;
    using TestConsole.Interfaces;
    using TestConsole.Models;
    using GiftAidCalculator = TestConsole.GiftAidCalculator;

    [TestFixture]
    public class GiftAidCalculatorShould
    {
        private GiftAidCalculator _giftAidCalculator;

        private Mock<IGetTaxRate> _mockTaxRateRepository;
        private Mock<IGetSupplementaryEventTaxRate> _mockSupplementaryEventTaxRateRepository;
        private Mock<IDecimalRounder> _mockDecimalRounder;

        [SetUp]
        public void SetUp()
        {
            _mockTaxRateRepository = new Mock<IGetTaxRate>();
            _mockSupplementaryEventTaxRateRepository = new Mock<IGetSupplementaryEventTaxRate>();
            _mockDecimalRounder = new Mock<IDecimalRounder>();
            _giftAidCalculator = new GiftAidCalculator(_mockTaxRateRepository.Object, _mockSupplementaryEventTaxRateRepository.Object, _mockDecimalRounder.Object);
        }

        [Test]
        public void Apply_The_Correct_Tax_Rate_To_A_Donation_Amount_In_Calculating_Gift_Aid()
        {
            // Arrange
            const decimal expectedGiftAidAmount = 25.00M;
            const decimal donationAmount = 100;

            _mockTaxRateRepository.Setup(x => x.GetTaxRate()).Returns(20);
            
            _mockDecimalRounder.Setup(x => x.Round(It.IsAny<decimal>())).Returns((decimal value) => value);         

            // Act
            var actualGiftAidAmount = _giftAidCalculator.CalculateGiftAid(donationAmount);
            
            // Assert
            Assert.That(expectedGiftAidAmount, Is.EqualTo(actualGiftAidAmount));
        }

        [TestCase("1.32")]
        [TestCase("4.0")]
        [TestCase("0.99")]
        [TestCase("10.56")]
        public void Return_A_Rounded_Amount_So_That_The_User_Sees_A_Rounded_Amount(string expectedRoundedGiftAidAmountString)
        {
            // Arrange
            var expectedRoundedGiftAidAmount = decimal.Parse(expectedRoundedGiftAidAmountString);
            
            _mockTaxRateRepository.Setup(x => x.GetTaxRate()).Returns(20);
           
            _mockDecimalRounder.Setup(x => x.Round(It.IsAny<decimal>())).Returns(expectedRoundedGiftAidAmount); 

            // Act
            var actualGiftAidAmount = _giftAidCalculator.CalculateGiftAid(100);

            // Assert
            Assert.That(expectedRoundedGiftAidAmount, Is.EqualTo(actualGiftAidAmount));
        }

        [Test]
        public void Apply_The_Correct_Supplementary_Event_Tax_Rate_In_Addition_To_The_Existing_Gift_Aid_Tax_Rate_When_Given_A_FundraisingEventType()
        {
            // Arrange
            const decimal expectedGiftAidAmount = 25;
            _mockTaxRateRepository.Setup(x => x.GetTaxRate()).Returns(10);

            _mockDecimalRounder.Setup(x => x.Round(It.IsAny<decimal>())).Returns((decimal value) => value);

            _mockSupplementaryEventTaxRateRepository.Setup(x => x.GetTaxRate(FundraisingEventType.Running)).Returns(10);

            // Act
            var actualGiftAidAmount = _giftAidCalculator.CalculateGiftAid(100, FundraisingEventType.Running);

            // Assert
            Assert.That(expectedGiftAidAmount, Is.EqualTo(actualGiftAidAmount));
        }
    }
}
