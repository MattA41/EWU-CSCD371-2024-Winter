using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Student(Guid Id, string FirstName, string LastName) : BaseEntity
{
    public override string Name => $"{FirstName} {LastName}";

}