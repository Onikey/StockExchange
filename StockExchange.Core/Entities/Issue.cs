namespace StockExchange.Core
{
    public class Issue : BaseEntity<decimal>//, IAggregateRoot
    {
        internal Issue() { }
        
        public string Name { get; internal set; }

        public string FullName { get; internal set; }

    }
}
