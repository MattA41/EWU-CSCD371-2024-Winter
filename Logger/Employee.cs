using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Employee : Person
{
    //I used implicity immplementation here
    public Employee(FullName name, Guid id) : base(name, id) { }
}
