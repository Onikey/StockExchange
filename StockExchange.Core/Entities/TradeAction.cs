using System;

namespace StockExchange.Core
{
    public static class TradeAction
    {
        public const string Buy = "P";
        public const string Sell = "S";

        public static string OpositeTradeAction(string action)
        {
            switch (action)
            {
                case TradeAction.Buy:
                    return TradeAction.Sell;
                case TradeAction.Sell:
                    return TradeAction.Buy;
                default:
                    throw new ArgumentException("Wrong trade action");
            }
        }
    }
}
