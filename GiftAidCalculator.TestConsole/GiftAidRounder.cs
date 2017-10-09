namespace GiftAidCalculator.TestConsole
{
    using System;
    using Interfaces;

    public class GiftAidRounder : IDecimalRounder
    {
        public decimal Round(decimal donationAmount)
        {
            return decimal.Round(donationAmount, 2, MidpointRounding.AwayFromZero);
        }
    }
}