namespace EvidencePojisteniDtos;

public class DetailPolicyDto
{
    public List <Guid> Contracts { get; set; }
    public Guid PolicyId { get; set; }
    public PolicyType Type { get; set; }
    public string Name { get; set; }
    public int MaxAmountOfInsuredItems { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly ValidTo { get; set; }

}
