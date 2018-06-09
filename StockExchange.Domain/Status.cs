using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Domain
{
    enum Status : int
    {
        New = 1,
        Deleted = 2,
        Affirm = 3,
        Completed = 4
    }
}
