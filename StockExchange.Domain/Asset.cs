using Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain
{
    public class Asset : Entity<decimal>
    {
        internal Asset() { }

       

        public string AcctNum { get; internal set; }
      
        public double Free { get; internal set; }       
        
  
    }
}
