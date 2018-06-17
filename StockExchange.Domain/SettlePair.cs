using Common.Abstractions;
using System.Collections.Generic;

namespace StockExchange.Domain
{
    public class SettlePair : Entity<decimal>
    {
        internal SettlePair()
        {
            Assets = new List<Asset>();
        }

       

        public string Name { get; internal set; }

        public string DepoNum { get; internal set; }

        public Firm Firm { get; internal set; }

        public List<Asset> Assets { get; set; }

    }
}
