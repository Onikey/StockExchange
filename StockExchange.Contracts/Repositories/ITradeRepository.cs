using StockExchange.Domain;
using System;
using System.Collections.Generic;


namespace StockExchange.Contracts.Repositories
{
    public interface ITradeRepository : IDisposable
    {
        void Add(Trade item);

        ICollection<Trade> GetAll();

        Trade GetById(decimal id);

        void Update(Trade item);

        void Delete(Trade item);

    }
}
