using StockExchange.Domain;
using System;
using System.Collections.Generic;


namespace StockExchange.Contracts.Repositories
{
   public interface ISettlePairRepository : IDisposable
    {
        void Add(SettlePair item);

        ICollection<SettlePair> GetAll();

        SettlePair GetById(decimal id);

        void Update(SettlePair item);

        void Delete(SettlePair item);
    }
}
