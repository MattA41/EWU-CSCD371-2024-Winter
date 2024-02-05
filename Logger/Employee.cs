using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Employee(Guid Id, string FirstName, string LastName, string Department) : BaseEntity
{
    protected Guid _id = Id;
    public string Name => $"{FirstName} {LastName} ({Department})";

    protected override string GetName()
    {
        throw new NotImplementedException();
    }

}
