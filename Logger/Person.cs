using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record class Person(FullName FullName, Guid NewId) : BaseEntity
{

    public override string Name { get => FullName.Name; }

}

