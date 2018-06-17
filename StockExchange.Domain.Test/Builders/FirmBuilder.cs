using Smocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain.Test.Builders
{
    class FirmBuilder
    {
        private Firm firm = new Firm();

        public FirmBuilder WithId(decimal id)
        {
          //  firm.Id = id;
            return this;
        }

        public FirmBuilder WithName(string name)
        {
            firm.Name = name;

            return this;
        }

        public FirmBuilder WithFullName(string fullName)
        {
            firm.FullName = fullName;

            return this;
        }

        public FirmBuilder WithSettlePair(SettlePair settlePair)
        {
            settlePair.Firm = firm;
            firm.SettlePairs.Add(settlePair);

            return this;
        }

        public Firm Build() => firm;
    }
}

