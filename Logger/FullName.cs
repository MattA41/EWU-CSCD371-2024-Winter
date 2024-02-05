using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FullName(string firstName, string lastName, string? middleName = null)
    {
        string FirstName { get; } = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
        public string LastName { get; } = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
        public string? MiddleName { get; } = middleName;
        public string Name => (MiddleName == null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}");
    }
}
