namespace GiftAidCalculator.TestConsole
{
    using Interfaces;
    using Models;

    public class GiftAidCalculator : ICalculateGiftAid
    {
        private readonly IGetTaxRate _taxRateRepository;
        private readonly IGetSupplementaryEventTaxRate _supplementaryEventTaxRateRepository;
        private readonly IDecimalRounder _decimalRounder;


        public GiftAidCalculator(IGetTaxRate taxRateRepository, IGetSupplementaryEventTaxRate supplementaryEventTaxRateRepository, IDecimalRounder decimalRounder)
        {
            _taxRateRepository = taxRateRepository;
            _supplementaryEventTaxRateRepository = supplementaryEventTaxRateRepository;
            _decimalRounder = decimalRounder;
        }

        public decimal CalculateGiftAid(decimal donationAmount)
        {
            var taxRate = _taxRateRepository.GetTaxRate();
            var giftAidRatio = taxRate / (100 - taxRate);
            return _decimalRounder.Round(donationAmount * giftAidRatio);
        }

        public decimal CalculateGiftAid(decimal donationAmount, FundraisingEventType eventType)
        {
            var taxRate = _taxRateRepository.GetTaxRate() + _supplementaryEventTaxRateRepository.GetTaxRate(eventType);
            var giftAidRatio = taxRate / (100 - taxRate);
            return _decimalRounder.Round(donationAmount * giftAidRatio);
        }
    }
}
