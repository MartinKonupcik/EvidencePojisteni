using EvidencePojisteniDtos;

namespace EvidencePojisteni.API.Entities;

public class Policy : Entity
{
    public PolicyType Type { get; set; }
    public string Name { get; set; } = null!;
    public Guid ContractId { get; set; }
    public Guid PersonId { get; set; }

    public Policy() { }
    public Policy(Guid id, DetailPolicyDto dto)
    {
        Id = id;
        Type = dto.Type;
        Name = dto.Name;
    }
    public void Update(DetailPolicyDto dto)
    {
        Type = dto.Type;
        Name = dto.Name;
    }
    public ListItemPolicyDto GetListItem() => new()
    {
        ContractId = ContractId,
        PersonId = PersonId,
        Type = Type,
        Name = Name
    };
}

