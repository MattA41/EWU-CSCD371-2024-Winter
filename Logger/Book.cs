using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Book(Guid Id, string Title, string Author) : IEntity
{
    
    public string Name => $"{Title} by {Author}";
}