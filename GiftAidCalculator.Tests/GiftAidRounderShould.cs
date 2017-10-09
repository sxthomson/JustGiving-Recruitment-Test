namespace GiftAidCalculator.Tests
{
    using TestConsole;
    using NUnit.Framework;

    [TestFixture]
    public class GiftAidRounderShould
    {
        [TestCase("1.316 ", "1.32")]
        [TestCase("3.999", "4.0")]
        [TestCase("0.992", "0.99")]
        [TestCase("10.555", "10.56")]
        public void Round_Any_Gift_Aid_Value_To_Two_Decimal_Places(string inputGiftAidString, string expectedOutputGiftAidString)
        {
            // Arrange
            var inputGiftAid = decimal.Parse(inputGiftAidString);
            var expectedOutputGiftAid = decimal.Parse(expectedOutputGiftAidString);

            var giftAidRounder = new GiftAidRounder();

            // Act
            var actualOutputGiftAid = giftAidRounder.Round(inputGiftAid);
            
            // Assert
            Assert.That(actualOutputGiftAid, Is.EqualTo(expectedOutputGiftAid));
        }
    }
}
