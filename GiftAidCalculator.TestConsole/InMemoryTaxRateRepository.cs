namespace GiftAidCalculator.TestConsole
{
    using Interfaces;

    public class InMemoryTaxRateRepository : IGetTaxRate, ISetTaxRate
    {
        private decimal _taxRate;

        public InMemoryTaxRateRepository(decimal taxRate)
        {
            _taxRate = taxRate;
        }

        public decimal GetTaxRate()
        {
            return _taxRate;
        }

        public void SetTaxRate(decimal taxRate)
        {
            _taxRate = taxRate;
        }
    }
}
