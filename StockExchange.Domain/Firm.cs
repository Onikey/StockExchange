using System.Collections.Generic;

namespace StockExchange.Domain
{
    class Firm
    {
        private Firm() { }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public List<SettlePair> SettlePairs { get; set; }

        public List<Trade> Trades { get; set; }

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
