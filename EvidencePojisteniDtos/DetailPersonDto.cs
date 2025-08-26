namespace EvidencePojisteniDtos;

public class DetailPersonDto
{
    public Guid PersonId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int Age { get; set; }
}
