using Common.Abstractions.Repository;
using StockExchange.Contracts.Repositories;
using StockExchange.Domain;
using System.Collections.Generic;
using System.Linq;

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
            this._repository.AddAndSave<Firm, decimal>(item);
        }

  

        public ICollection<Firm> GetAll()
        {
            string query = "SELECT id , name , full_name 'fullName' " +
                           "FROM Firm " +
                           "WHERE properties NOT LIKE '%NONE%' AND deleted != '*' AND name NOT IN ('EMAIL','BRIDGE', 'INTER', 'INFO','ISSUE','VENA','RTSIS','ADMIN')";
            return this._repository.ExecuteQueryResultList<Firm>(query).ToList();    // GetAll<Firm>().Where(x=> !x.properties.Contains( "NONE") && x.deleted != "*" && !x.Name.) .ToList();
        }

        public Firm GetById(decimal id)
        {
            return this._repository.FindSingle<Firm>(x => x.Id == id);
        }

        //public T GetByIdAs<T>(int id) where T : class, IDto, new()
        //{
        //    return this._repository.Find<Firm>(x => x.Id == id).ProjectTo<T>().Single();
        //}

        public void Update(Firm item)
        {
            this._repository.UpdateAndSave<Firm, decimal>(item);
        }

        public void Delete(Firm item)
        {
            this._repository.DeleteAndSave<Firm, decimal>(item);
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
