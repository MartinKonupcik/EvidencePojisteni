namespace EvidencePojisteniDtos;

public class ListItemContractDto
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid PolicyId { get; set; }
    public bool Active { get; set; }
}
