namespace GiftAidCalculator.TestConsole
{
    using Interfaces;
    using Models;
    using System.Collections.Generic;

    public class InMemorySupplementaryEventTaxRateRepository : IGetSupplementaryEventTaxRate
    {
        private readonly IDictionary<FundraisingEventType, decimal> _fundraisingEventTypeSuppemenatoryTaxDictionary = new Dictionary<FundraisingEventType, decimal>
        {
            {
               FundraisingEventType.Running, 5M
            },
            {
                FundraisingEventType.Swimming, 3M
            }
        };

        public decimal GetTaxRate(FundraisingEventType eventType)
        {
            return _fundraisingEventTypeSuppemenatoryTaxDictionary.ContainsKey(eventType)
                ? _fundraisingEventTypeSuppemenatoryTaxDictionary[eventType]
                : 0;
        }
    }
}
