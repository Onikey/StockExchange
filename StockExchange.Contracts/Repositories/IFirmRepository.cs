using StockExchange.Domain;
using System;
using System.Collections.Generic;


namespace StockExchange.Contracts.Repositories
{
    public interface IFirmRepository : IDisposable
    {
        void Add(Firm item);

        ICollection<Firm> GetAll();

        Firm GetById(decimal id);

        void Update(Firm item);

        void Delete(Firm item);
    }
}
