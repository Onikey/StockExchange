using System.Collections.Generic;

namespace StockExchange.Domain
{
    public class SettlePair
    {
        private SettlePair() { }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string DepoNum { get; private set; }

        public Firm Firm { get; private set; }

        public List<Asset> Assets { get; set; }

    }
}
