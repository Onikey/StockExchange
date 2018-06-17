using Common.Abstractions;
using Common.Abstractions.Entities;

namespace StockExchange.Domain
{
    public class Issue : Entity<decimal>, IAggregateRoot
    {
        internal Issue() { }
        
        public string Name { get; internal set; }

        public string FullName { get; internal set; }

    }
}
