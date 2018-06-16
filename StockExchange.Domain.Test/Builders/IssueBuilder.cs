using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain.Test.Builders
{
    class IssueBuilder
    {



        private Issue issue = new Issue();

        public IssueBuilder WithId(int id)
        {
            issue.Id = id;
            return this;
        }

        public IssueBuilder WithName(string name)
        {
            issue.Name = name;

            return this;
        }

        public IssueBuilder WithFullName(string fullName)
        {
            issue.FullName = fullName;

            return this;
        }

        
        public Issue Build() => issue;

    }
}
