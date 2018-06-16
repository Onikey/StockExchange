using Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain
{
    public class Issue : Entity<int>
    {
        internal Issue() { }

        

        public string Name { get; internal set; }

        public string FullName { get; internal set; }

    }
}
