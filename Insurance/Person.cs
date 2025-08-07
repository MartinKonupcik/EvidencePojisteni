using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EvidencePojisteni;

public class Person
{
    
    public int PersonNumber { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }

    public List<Insurance>? Insurances { get; set; } = new List<Insurance>();

    public Person(string firstName, string lastName, string phone, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Age = age;
    }

    public override string ToString()
    {
        return $"{PersonNumber}, {FirstName} {LastName}, Phone: {Phone}, Age: {Age}";
    }
}