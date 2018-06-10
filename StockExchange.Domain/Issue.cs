using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain
{
    public class Issue
    {
        private Issue() { }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; private set; }

    }
}
