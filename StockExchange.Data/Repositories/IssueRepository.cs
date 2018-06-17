using Common.Abstractions.Repository;
using StockExchange.Contracts.Repositories;
using StockExchange.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StockExchange.Data.Repositories
{
    
    public class IssueRepository : IIssueRepository
    {

        private readonly IAsyncGenericRepository _repository;

        public IssueRepository(IAsyncGenericRepository genericRepository)
        {
            this._repository = genericRepository;
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }

        public ICollection<Issue> GetAll()
        {
            return this._repository.GetAll<Issue>().ToList();
        }

        public Issue GetById(decimal id)
        {
            return this._repository.FindSingle<Issue>(x => x.Id == id);
        }
    }
}
