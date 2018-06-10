using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain
{
    public class Asset
    {
        private Asset() { }

        public int Id { get; private set; }

        public string AcctNum { get; private set; }
      
        public double Free { get; private set; }       
        
  
    }
}
