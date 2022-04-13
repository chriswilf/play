using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfLinq
{
    public static class DataGenerator
    {

        public static IEnumerable<int> RandomSequence(int minInclusive, int maxExclusive)
        {
            int num = 0;
            Random rng = new Random();
            while (true)
            {
                if(num == 1000000)

                num++;
                yield return rng.Next(minInclusive, maxExclusive);


            }
        }


        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return (int)getrandom.Next(min, max);
            }
        }

        public static UserPortfolio GeneratePortfolio(int fundCount)
        {
            var portfolio = new UserPortfolio() { UserId = 1, UserFunds = AddFunds(fundCount) };

            return portfolio;
        }

        public static List<InvestmentFund> AddFunds(int fundCount)
        {
            var funds = new List<InvestmentFund>()
            {
                new InvestmentFund(){ FundId= "F1", FundName = "Fund1", FundShareHoldings = AddHoldings(30)},
                new InvestmentFund(){ FundId= "F2", FundName = "Fund2", FundShareHoldings = AddHoldings(10)},
                new InvestmentFund(){ FundId= "F3", FundName = "Fund3", FundShareHoldings = AddHoldings(18)},
                new InvestmentFund(){ FundId= "F4", FundName = "Fund4", FundShareHoldings = AddHoldings(6)},
            };

            for (int i = 5; i <= fundCount; i++)
            {
                funds.Add(new InvestmentFund()
                {
                    FundId = $"F{i}",
                    FundShareHoldings = AddHoldings(GetRandomNumber(1, 50))
                });
            }

            return funds;

        }

        public static List<FundShareHolding> AddHoldings(int holdingCount )
        {
            var funds = new List<FundShareHolding>()
            {
                new FundShareHolding(){ FundHoldingId= "SH1", FundHoldingName = "MS", CurrentSharePrice = 10, SharesHeld = 10 },
                new FundShareHolding(){ FundHoldingId= "SH2", FundHoldingName = "Apple", CurrentSharePrice = 11, SharesHeld = 10},
                new FundShareHolding(){ FundHoldingId= "SH3", FundHoldingName = "Google", CurrentSharePrice = 12, SharesHeld = 10},
                new FundShareHolding(){ FundHoldingId= "SH4", FundHoldingName = "Facebook", CurrentSharePrice = 13, SharesHeld = 10},
             };

            for(int i=5; i <= holdingCount; i++)
            {
                funds.Add(new FundShareHolding() { 
                    FundHoldingId = $"SH{i}", 
                    FundHoldingName = $"Company{i}", 
                    CurrentSharePrice = GetRandomNumber(10, 500), 
                    SharesHeld = GetRandomNumber(10, 100)
                });
            }

            return funds;

        }

        public static string[] GetListOfStrings(int num)
        {
            string[] strings = new string[num];
            for(int i=0; i<num; i++)
            {
                strings[i] = $"String{i}";
            }

            return strings;
        }

    }
}
