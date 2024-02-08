using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Employee : Person
{
    //This is an implicit implementation as it gets from Person
    public Employee(FullName name, Guid id) : base(name, id) { }
}
