using StockExchange.Core;
using System.Collections.Generic;

namespace StockExchange.Core
{
    public class SettlePair : BaseEntity<decimal>
    {
        internal SettlePair()
        {
            Assets = new List<Asset>();
        }

       

        public string Name { get; internal set; }

        public string DepoNum { get; internal set; }

        public Firm Firm { get; internal set; }

        public string FirmName { get; set; }

        public List<Asset> Assets { get; set; }

    }
}
