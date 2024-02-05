using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Book(Guid Id, string Title, string Author) : BaseEntity
{
    
    public override string Name =>  $"{Title} by {Author}";
}