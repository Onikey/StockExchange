using Common.Abstractions;
using Common.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockExchange.Domain
{
    public class Firm : Entity<int>, IAggregateRoot
    {
        internal Firm()
        {
            SettlePairs = new List<SettlePair>();
            Trades = new List<Trade>();
        }

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
            var newTrade = Trade.Create(
                issue: issue,
                price: price,
                qty: qty,
                initFirm: this,
                initSettlePair: initSettlePair,
                initAction: initAction,
                initMemo: initMemo,
                confFirm: confFirm);

            Trades.Add(newTrade);

            confFirm.ProposeTrade(newTrade);
        }

        internal void ProposeTrade(Trade newTrade)
        {
            if (newTrade.Status == Status.New && !Trades.Contains(newTrade))
            {
                Trades.Add(newTrade);
            }
        }

        public void removeTrade(Trade trade)
        {
            Trades.Remove(trade);
        }

        public void affirmTrade(Trade trade)
        {

        }


    }
}
