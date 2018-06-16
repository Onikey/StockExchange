using Common.Abstractions.Repository;
using StockExchange.Contracts.Repositories;
using StockExchange.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Data.Repositories
{
    public class FirmRepository : IFirmRepository
    {
        private readonly IAsyncGenericRepository _repository;

        public FirmRepository(IAsyncGenericRepository genericRepository)
        {
            this._repository = genericRepository;
        }

        public void Add(Firm item)
        {
            this._repository.AddAndSave<Firm, int>(item);
        }

        //public ICollection<T> GetAllAs<T>() where T : class, IDto, new()
        //{
        //    return this._repository.GetAll<Firm>().ProjectTo<T>().ToList();
        //}

        public ICollection<Firm> GetAll()
        {
            return this._repository.GetAll<Firm>().ToList();
        }

        public Firm GetById(int id)
        {
            return this._repository.FindSingle<Firm>(x => x.Id == id);
        }

        //public T GetByIdAs<T>(int id) where T : class, IDto, new()
        //{
        //    return this._repository.Find<Firm>(x => x.Id == id).ProjectTo<T>().Single();
        //}

        public void Update(Firm item)
        {
            this._repository.UpdateAndSave<Firm, int>(item);
        }

        public void Delete(Firm item)
        {
            this._repository.DeleteAndSave<Firm, int>(item);
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
