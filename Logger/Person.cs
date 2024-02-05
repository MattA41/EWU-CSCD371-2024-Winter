using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
    public record class Person(FullName FullName) : BaseEntity
    {
        
        public override string Name { get => fullName.Name; }
        public override Guid Id { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    }

