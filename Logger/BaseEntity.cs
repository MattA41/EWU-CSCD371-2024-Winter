using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract record class BaseEntity
    {
        public abstract Guid Id { get; init; }
        public abstract string Name { get; }
    }
}
