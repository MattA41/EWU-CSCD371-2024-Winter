using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
    public struct FullName(string firstName, string lastName, string? middleName = null)
    {
    //We wanted the names to be unique to the item they were assigned and be immutable so that nothing can change their name when referencing it
    //That is why we used the value type to define a FullName
   
    public string FirstName { get; } = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
        public string LastName { get; } = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
        public string? MiddleName { get; } = middleName;
        public string Name => (MiddleName == null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}");
    }

