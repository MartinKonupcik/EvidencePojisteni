using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace EvidencePojisteni;

public class Person
{
    [Key]
    public Guid PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }

    public List<Contract>? Insurances { get; set; } = new List<Contract>();

    public Person(string firstName, string lastName, string phone, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Age = age;
    }
}
