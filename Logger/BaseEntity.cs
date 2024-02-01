using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    internal class BaseEntity : IEntity
    {
        public Guid Id { get; init; }

        
        string IEntity.Name
        {
            get
            {
                throw new NotImplementedException("Name property not implemented in BaseEntity");
            }
        }
    }
}
