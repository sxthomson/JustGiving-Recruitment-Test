using System;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
	    private static GiftAidCalculator GiftAidCalculator = CreateGiftAidCalculator(17.5M);

		static void Main(string[] args)
		{
			// Calc Gift Aid Based on Previous
			Console.WriteLine("Please Enter donation amount:");
			Console.WriteLine(GiftAidAmount(decimal.Parse(Console.ReadLine())));
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}

		static decimal GiftAidAmount(decimal donationAmount)
		{
		    return GiftAidCalculator.CalculateGiftAid(donationAmount);
		}

	    static GiftAidCalculator CreateGiftAidCalculator(decimal taxRate)
	    {
	        return new GiftAidCalculator(new InMemoryTaxRateRepository(taxRate), new InMemorySupplementaryEventTaxRateRepository(), new GiftAidRounder());
	    }
	}
}
