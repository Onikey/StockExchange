using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain.Test.Builders
{
    class AssetBuilder
    {
        private Asset asset = new Asset();

        public AssetBuilder withId(decimal id)
        {
          //  asset.Id = id;
            return this;

        }

        public AssetBuilder withAcctNum(string acctNum)
        {
            asset.AcctNum = acctNum;
            return this;
        }

        public AssetBuilder withFree(double free)
        {
            asset.Free = free;
            return this;

        }

        public Asset Build() => asset;
    }
}
