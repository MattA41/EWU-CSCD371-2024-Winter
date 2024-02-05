using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Student : Person
{
    public Student(FullName name) : base(name) { }

}