using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace EvidencePojisteni.API.Entities;

public class Person: Entity
{
    public string FirstName { get; set; }= null!;
    public string LastName { get; set; }= null!;
    public string Phone { get; set; }= null!;
    public int Age { get; set; }
}
