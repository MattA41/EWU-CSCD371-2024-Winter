using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Student : Person
{
    //implicit implementation works best here 
    public Student(FullName name, Guid id) : base(name, id) { }

}