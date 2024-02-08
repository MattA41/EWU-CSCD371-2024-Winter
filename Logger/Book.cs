using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Book(string Title, Guid Id)  : BaseEntity
{
    public override string Name { get; } = Title;
    private readonly Guid id = Id;

}