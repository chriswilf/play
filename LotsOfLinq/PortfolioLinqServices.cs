using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfLinq
{
    public class PortfolioLinqServices
    {
        private UserPortfolio _portfolio;
        public PortfolioLinqServices(UserPortfolio up)
        {
            _portfolio = up;
        }

        public string GetFundCount()
        {
            return _portfolio.UserFunds.Count.ToString();
        }

        public string GetFundHoldingsCount(string id)
        {
            return _portfolio.UserFunds.First(f => f.FundId == id).FundShareHoldings.Count().ToString();
        }

        public string GetPortfolioValue()
        {
            return _portfolio.PortfolioValue.ToString();
        }
    }
}
