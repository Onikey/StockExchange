using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain.Test.Builders
{
    class SettlePairBuilder
    {
        private SettlePair settlePair = new SettlePair();

        public SettlePairBuilder WithId(int id)
        {
            settlePair.Id = id;
            return this;
        }
        public SettlePairBuilder WithName(string name)
        {
            settlePair.Name = name;
            return this;
        }
        public SettlePairBuilder WithDepoNum(string depoNum)
        {
            settlePair.DepoNum = depoNum;
            return this;
        }

        public SettlePairBuilder WithAsset(Asset asset)
        {
            asset.AcctNum = settlePair.DepoNum;
            settlePair.Assets.Add(asset);
            return this;
        }

        public SettlePair Build() => settlePair;
    }
}
