using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfLinq
{
    //context map 
   

    
        public class UserPortfolio
        {
            public int UserId { get; set; }

            public List<InvestmentFund> UserFunds { get; set; } 
            
            public decimal? PortfolioValue { 
                get
                {
                    return UserFunds.Sum(uf => uf.FundAmount);
                } 
            }
        }

        public class InvestmentFund 
        {
            public string? FundId { get; set; }
            public string? FundName { get; set; }
            public List<FundShareHolding> FundShareHoldings { get; set; }  

            public decimal? FundAmount
            {
                get
                {
                    return FundShareHoldings.Sum(fh => fh.HoldingValue);
                }
            }
        }

        public class FundShareHolding
    {
            public string? FundHoldingId { get; set; }
            public string? FundHoldingName { get; set; }
            public decimal CurrentSharePrice { get; set; }
            public int SharesHeld { get; set; }
           
            public decimal HoldingValue { 
                get
                {
                    return CurrentSharePrice * SharesHeld;
                }
            }
            


        }

        
    }

