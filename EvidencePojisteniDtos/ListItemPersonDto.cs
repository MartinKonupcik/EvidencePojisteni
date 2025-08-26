namespace EvidencePojisteniDtos;

public class ListItemPersonDto
{
    public Guid PersonId { get; set; }
    public Guid ContractId { get; set; }
    public Guid PolicyId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
