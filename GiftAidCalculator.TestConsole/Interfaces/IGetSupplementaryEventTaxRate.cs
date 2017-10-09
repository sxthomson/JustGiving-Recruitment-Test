namespace GiftAidCalculator.TestConsole.Interfaces
{
    using Models;

    public interface IGetSupplementaryEventTaxRate
    {
        decimal GetTaxRate(FundraisingEventType eventType);
    }
}