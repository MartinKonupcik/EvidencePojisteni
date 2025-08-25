namespace EvidencePojisteni.API.Services;

using EvidencePojisteniDto;

public class ContractService
{
    private List<ListItemContractDto> _contract =
    [
        new()
        {
            Id= Guid.NewGuid(),
           PersonId= Guid.NewGuid(),
              PolicyId= Guid.NewGuid(),
            Active = true
        },
        new()
        {
            Id= Guid.NewGuid(),
            PersonId= Guid.NewGuid(),
            PolicyId= Guid.NewGuid(),
            Active = true
        }
    ];

    public async Task<ListItemContractDto?> Get(Guid contractId)
    {
        await Task.Delay(100).ConfigureAwait(false);
        return _contract.FirstOrDefault(c => c.Id == contractId);
    }

    public async Task<ListItemContractDto[]> GetList()
    {
        await Task.Delay(100).ConfigureAwait(false);
        return [.. _contract];
    }

    public async Task Create(DetailContractDto contractDto)
    {
        var contract = new ListItemContractDto
        {
            PolicyId = contractDto.PolicyId,
            PersonId = contractDto.PersonId,
            Active = contractDto.Active
        };
        _contract.Add(contract);
        await Task.Delay(100).ConfigureAwait(false);
    }

    public async Task<string> Delete(Guid contractId)
    {
        var contract = _contract.FirstOrDefault(c => c.Id == contractId);
        if (contract == null)
        {
            return "NotFound";
        }
        _contract.Remove(contract);
        return "Deleted";
    }

    public async Task<bool> Update(Guid contractId, DetailContractDto contractDto)
    {
        var contract = _contract.FirstOrDefault(c => c.Id == contractId);
        if (contract == null)
        {
            return false;
        }
        contractDto.PolicyId = contractDto.PolicyId;
        contractDto.PersonId = contractDto.PersonId;
        contractDto.ValidFrom= contractDto.ValidFrom;
        contractDto.ValidTo= contractDto.ValidTo;
        contractDto.Amount= contractDto.Amount;
        contractDto.PolicyType= contractDto.PolicyType;
        contract.Active = contractDto.Active;
        await Task.Delay(100).ConfigureAwait(false);
        return true;
    }
}
