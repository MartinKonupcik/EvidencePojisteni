using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace EvidencePojisteni;

public class Person
{
    [Key]
    public Guid PersonId { get; set; } 
    public string FirstName { get; set; }= null!;
    public string LastName { get; set; }= null!;
    public string Phone { get; set; }= null!;
    public int Age { get; set; }
}
