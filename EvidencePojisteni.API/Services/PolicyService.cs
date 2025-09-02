using EvidencePojisteni.API.Entities;
using EvidencePojisteniDtos;
using System;

namespace EvidencePojisteni.API.Services;

public class PolicyService
{
    private readonly List<Policy> _policyList =
        [
            new()
            {
                Id = Guid.NewGuid(),
                Type = PolicyType.Health,
                Name = "Health care",
                Contracts = [Guid.NewGuid()],
                MaxAmountOfInsuredItems = 5,
                ValidFrom = DateOnly.FromDateTime(DateTime.Now),
                ValidTo = DateOnly.FromDateTime(DateTime.Now.AddYears(1))
            },
            new()
            {
                Id = Guid.NewGuid(),
                Type = PolicyType.Life,
                Name = "Life insurance",
                Contracts = [Guid.NewGuid()],
                MaxAmountOfInsuredItems = 3,
                ValidFrom = DateOnly.FromDateTime(DateTime.Now),
                ValidTo = DateOnly.FromDateTime(DateTime.Now.AddYears(1))
            }
        ];
 
    public async Task<DetailPolicyDto?> Get(Guid policyId)
    {
        await Task.Delay(100).ConfigureAwait(false);

        return _policyList.FirstOrDefault(p => p.Id == policyId)?.GetDetail();
    }

    public async Task<ListItemPolicyDto[]> GetListItems()
    {
        await Task.Delay(100).ConfigureAwait(false);

        return [.. _policyList.Select(p => p.GetListItem())];
    }

    public async Task Create(DetailPolicyDto policyDto)
    {     
        _policyList.Add(new Policy(Guid.NewGuid(),policyDto));
        await Task.Delay(50).ConfigureAwait(false);
    }

    public async Task<bool> Delete(Guid id)
    {
        if (_policyList.Any(c => c.Id == id))
        {
           _policyList.RemoveAll(c => c.Id == id);
            return true;
        }
        return false;
    }

    public async Task<bool> Update(Guid policyId, DetailPolicyDto policyDto)
    {
        _policyList.FirstOrDefault(c => c.Id == policyId)?.Update(policyDto);
        await Task.Delay(100).ConfigureAwait(false);
        return true;
    }
}
