using StockExchange.Core;
using System.Collections.Generic;

namespace StockExchange.Core
{
    public class Firm : BaseEntity<decimal>//, IAggregateRoot
    {
        internal Firm()
        {
            SettlePairs = new List<SettlePair>();
            TradesAsConf = new List<Trade>();
            TradesAsInit = new List<Trade>();
        }

        public string Name { get; internal set; }

        public string FullName { get; internal set; }

        public List<SettlePair> SettlePairs { get; private set; }

        public List<Trade> TradesAsInit { get; private set; }

        public List<Trade> TradesAsConf { get; private set; }

        public void CreateTrade(
            Issue issue,
            double price,
            int qty,
            SettlePair initSettlePair,
            string initAction,
            string initMemo,
            Firm confFirm)
        {
            var newTrade = Trade.Create(
                issue: issue,
                price: price,
                qty: qty,
                initFirm: this,
                initSettlePair: initSettlePair,
                initAction: initAction,
                initMemo: initMemo,
                confFirm: confFirm);

            TradesAsInit.Add(newTrade);

            confFirm.ProposeTrade(newTrade);
        }

        internal void ProposeTrade(Trade newTrade)
        {
            if (newTrade.Status == Status.New && !TradesAsConf.Contains(newTrade))
            {
                TradesAsConf.Add(newTrade);
            }
        }

        public void RemoveTrade(Trade trade)
        {
            TradesAsConf.Remove(trade);
            TradesAsInit.Remove(trade);
        }

        public void AffirmTrade(Trade trade)
        {

        }


    }
}
