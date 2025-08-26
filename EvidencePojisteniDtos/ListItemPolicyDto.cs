namespace EvidencePojisteniDtos;

public class ListItemPolicyDto
{
    public Guid PolicyId { get; set; }
    public Guid ContractId { get; set; }
    public Guid PersonId { get; set; }
    public PolicyType Type { get; set; }
    public string Name { get; set; }
}
