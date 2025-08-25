using EvidencePojisteni.API.Entities;
using EvidencePojisteniDto;

namespace EvidencePojisteni.API.Entities;

public class Contract : Entity
{
    public Guid PersonId { get; set; }
    public Guid PolicyId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public decimal Amount { get; set; }
    public bool Active { get; set; } = true;
    public PolicyType PolicyType { get; set; }

    public Contract() { }

    public Contract(Guid ContractId, DetailContractDto Dto)
    {
        Id = ContractId;
        PersonId = Dto.PersonId;
        PolicyId = Dto.PolicyId;
        ValidFrom = Dto.ValidFrom;
        ValidTo = Dto.ValidTo;
        Amount = Dto.Amount;
        Active = true;
    }

    public void Update(DetailContractDto Dto)
    {
        PersonId = Dto.PersonId;
        PolicyId = Dto.PolicyId;
        PolicyType = Dto.PolicyType;
        ValidFrom = Dto.ValidFrom;
        ValidTo = Dto.ValidTo;
        Amount = Dto.Amount;
        Active = Dto.Active;
    }

    public ListItemContractDto GetListItem()=> new ListItemContractDto
    {
        Id = Id,
        PersonId = PersonId,
        PolicyId = PolicyId,
        Active = Active
    };
}
