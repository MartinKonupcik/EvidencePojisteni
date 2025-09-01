
using EvidencePojisteni.API.Entities;
using EvidencePojisteniDtos;

namespace EvidencePojisteni.API.Services;
public class ContractService
{
    private List<Contract> _contractList =
    [
        new()
        {
            Id= Guid.NewGuid(),
           PersonId= Guid.NewGuid(),
              PolicyId= Guid.NewGuid(),
            Active = true,
            ValidFrom= DateTime.Now,
            ValidTo= DateTime.Now.AddYears(1),
            Amount= 1000m,
            PolicyType= PolicyType.Health
        },
        new()
        {
            Id= Guid.NewGuid(),
            PersonId= Guid.NewGuid(),
            PolicyId= Guid.NewGuid(),
            Active = true,
            ValidFrom= DateTime.Now,
            ValidTo= DateTime.Now.AddYears(2),
            Amount= 2000m,
            PolicyType= PolicyType.Life
        }
    ];

    public async Task<DetailContractDto?> Get(Guid contractId)
    {
        await Task.Delay(100).ConfigureAwait(false);
        return _contractList.FirstOrDefault(c => c.Id == contractId)?.GetDetail();
    }

    public async Task<ListItemContractDto[]> GetList()
    {
        await Task.Delay(100).ConfigureAwait(false);
        return _contractList.Select(static x => x.GetListItem()).ToArray();
    }

    public async Task Create(DetailContractDto contractDto)
    {
        _contractList.Add(new(Guid.NewGuid(), contractDto));
        await Task.Delay(100).ConfigureAwait(false);
    }

    public async Task<string> Delete(Guid contractId)
    {
        if (_contractList.Any(c => c.Id == contractId))
        {
            _ = _contractList.RemoveAll(c => c.Id == contractId);
            return "Deleted";
        }
        return "Not Found";
    }

    public async Task<bool> Update(Guid contractId, DetailContractDto contractDto)
    {
        _contractList.FirstOrDefault(c => c.Id == contractId)?.Update(contractDto);
        await Task.Delay(100).ConfigureAwait(false);
        return true;
    }
}
