namespace EvidencePojisteniDtos;

public class ListItemPersonDto
{
    public Guid PersonId { get; set; }
    public required List <Guid> ContractId { get; set; }
    public Guid PolicyId { get; set; }
    public string FirstName { get; set; }= null!;
    public string LastName { get; set; }= null!;
}
