using EvidencePojisteniDtos;

namespace EvidencePojisteni.API.Entities;

public class Policy : Entity
{
    public PolicyType Type { get; set; }
    public string Name { get; set; } = null!;
    public List<Guid> Contracts { get; set; }
    public int MaxAmountOfInsuredItems { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly ValidTo { get; set; }
    
    public Policy() { }

    public Policy(Guid id, DetailPolicyDto dto)
    {
        Id = id;
        Type = dto.Type;
        Name = dto.Name;
        ValidFrom = dto.ValidFrom;
        ValidTo = dto.ValidTo;
        MaxAmountOfInsuredItems = dto.MaxAmountOfInsuredItems;
    }
    public void Update(DetailPolicyDto dto)
    {
        Type = dto.Type;
        Name = dto.Name;
        ValidFrom = dto.ValidFrom;
        ValidTo = dto.ValidTo;
        MaxAmountOfInsuredItems = dto.MaxAmountOfInsuredItems;
    }
    public ListItemPolicyDto GetListItem() => new()
    {
        PolicyId = Id,
        Contracts = Contracts,
        Type = Type,
        Name = Name,
        ValidFrom = ValidFrom,
        ValidTo = ValidTo,
        MaxAmountOfInsuredItems = MaxAmountOfInsuredItems,
    };

    public DetailPolicyDto GetDetail() => new()
    {
        PolicyId = Id,
        Type = Type,
        Name = Name,
        ValidFrom = ValidFrom,
        ValidTo = ValidTo,
        MaxAmountOfInsuredItems = MaxAmountOfInsuredItems,
    };
}

