using System.Collections.Generic;

namespace StockExchange.Domain
{
    public class Firm
    {
        internal Firm() { }

        public int Id { get; internal set; }

        public string Name { get; internal set; }

        public string FullName { get; internal set; }

        public List<SettlePair> SettlePairs { get; private set; }

        public List<Trade> Trades { get; private set; }

        public void CreateTrade(
            Issue issue,
            double price,
            int qty,
            SettlePair initSettlePair,
            string initAction,
            string initMemo,
            Firm confFirm)
        {
            Trades.Add(Trade.Create(
                issue: issue,
                price: price,
                qty: qty,
                initFirm: this,
                initSettlePair: initSettlePair,
                initAction: initAction,
                initMemo: initMemo,
                confFirm: confFirm));
        }
    }
}
