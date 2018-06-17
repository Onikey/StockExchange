using StockExchange.Domain;
using System;
using System.Collections.Generic;


namespace StockExchange.Contracts.Repositories
{
    public interface IAssetRepository : IDisposable
    {
        void Add(Asset item);

        ICollection<Asset> GetAll();

        Asset GetById(decimal id);

        void Update(Asset item);

        void Delete(Asset item);
    }
}
