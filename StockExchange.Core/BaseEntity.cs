using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Core
{
    public abstract class BaseEntity<Tid> where Tid : IEquatable<Tid>
    {
        public BaseEntity(Tid id)
        {
            if (EqualityComparer<Tid>.Default.Equals(id, default(Tid)))
                throw new ArgumentException("The id can't be the default value.");

            this.Id = id;
        }

        public BaseEntity()
        {

        }

        public Tid Id { get; set; }
    }
}
