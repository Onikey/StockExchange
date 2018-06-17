using StockExchange.Domain;
using System;
using System.Collections.Generic;


namespace StockExchange.Contracts.Repositories
{
    public interface IIssueRepository : IDisposable
    {

        ICollection<Issue> GetAll();

        Issue GetById(decimal id);

    }
}
