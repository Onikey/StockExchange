using StockExchange.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Contracts.Repositories
{
    public interface IFirmRepository : IDisposable
    {
        void Add(Firm item);

        ICollection<Firm> GetAll();

        Firm GetById(int id);

        void Update(Firm item);

        void Delete(Firm item);
    }
}
