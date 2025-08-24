namespace EvidencePojisteni.API.Services;

using EvidencePojisteniDto;

public class ContractService
{
    private List<ListItemContractDto> _contract =
    [
        new()
        {
            ContractId= Guid.NewGuid(),
            ValidFrom = DateTime.Now.AddYears(-1),
            ValidTo = DateTime.Now.AddYears(5),
            Amount = 1000000,
            Active = true
        },
        new()
        {
            ValidFrom = DateTime.Now.AddYears(-1),
            ValidTo = DateTime.Now.AddYears(7),
            Amount = 500000,
            Active = true
        }
    ];

    public async Task<ListItemContractDto?> Get(Guid contractId)
    {
        await Task.Delay(100).ConfigureAwait(false);
        return _contract.FirstOrDefault(c => c.ContractId == contractId);
    }

    public async Task<ListItemContractDto[]> GetList()
    {
        await Task.Delay(100).ConfigureAwait(false);
        return [.. _contract];
    }

    public async Task Create(NewContractDto contractDto)
    {
        var contract = new ListItemContractDto
        {
            ContractId = Guid.NewGuid(),
            ValidFrom = contractDto.ValidFrom,
            ValidTo = contractDto.ValidTo,
            Amount = contractDto.Amount,
            Active = contractDto.Active
        };
        _contract.Add(contract);
        await Task.Delay(100).ConfigureAwait(false);
    }

    public async Task<string> Delete(Guid contractId)
    {
        var contract = _contract.FirstOrDefault(c => c.ContractId == contractId);
        if (contract == null)
        {
            return "NotFound";
        }
        _contract.Remove(contract);
        return "Deleted";
    }

    public async Task<bool> Update(Guid contractId, DetailContractDto contractDto)
    {
        var contract = _contract.FirstOrDefault(c => c.ContractId == contractId);
        if (contract == null)
        {
            return false;
        }
        contract.ValidFrom = contractDto.ValidFrom;
        contract.ValidTo = contractDto.ValidTo;
        contract.Amount = contractDto.Amount;
        contract.Active = contractDto.Active;
        await Task.Delay(100).ConfigureAwait(false);
        return true;
    }
}
