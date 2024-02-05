using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Employee(Guid Id, string FirstName, string LastName, string Department) : BaseEntity
{

    public override string Name => $"{FirstName} {LastName} ({Department})";
}
