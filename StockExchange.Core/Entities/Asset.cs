using StockExchange.Core;

namespace StockExchange.Core
{
    public class Asset : BaseEntity<decimal>
    {
        internal Asset() { }

       

        public string AcctNum { get; internal set; }
      
        public double Free { get; internal set; }       
        
  
    }
}
