namespace ClassDemo;

public class Person
{
    public Person(string firstName)
    {
        FirstName = firstName;
    }

    private string? _firstName;

    public string FirstName { 
        get => _firstName!;
        set
        {
            _firstName = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    public string? MiddleName { get; set; }

    //public string LastName { get; set; }
}