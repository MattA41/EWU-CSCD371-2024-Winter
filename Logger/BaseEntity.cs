using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract record BaseEntity : IEntity
    {
        public Guid Id { get; init; }

        public string Name => "Default Name";

    }
}
