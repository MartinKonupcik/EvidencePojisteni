namespace EvidencePojisteni.API.Services;

public class ContractService
{
    private List<Contract> _contract =
    [
        new()
        {
            ContractId = Guid.NewGuid(),
            PersonId = Guid.NewGuid(),
            PolicyId = Guid.NewGuid(),
            ValidFrom = DateTime.Now.AddYears(-1),
            ValidTo = DateTime.Now.AddYears(5),
            Amount = 1000000,
            Active = true
        },
        new()
        {
            ContractId = Guid.NewGuid(),
            PersonId = Guid.NewGuid(),
            PolicyId = Guid.NewGuid(),
            ValidFrom = DateTime.Now.AddYears(-1),
            ValidTo = DateTime.Now.AddYears(7),
            Amount = 500000,
            Active = true
        }
    ];

    public async Task<Contract?> Get(Guid id)
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return _contract.SingleOrDefault(p => p.ContractId == id);
    }

    public async Task<Contract[]> GetList()
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return [.. _contract];
    }

    public async Task Create(Contract contract)
    {
        // Assign a new Guid if not already set
        if (contract.ContractId == Guid.Empty)
        {
            contract.ContractId = Guid.NewGuid();
        }

        _contract.Add(contract);

        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);
    }

    public async Task<string> Delete(Guid id)
    {
        var toDelete = _contract.Where(x => x.ContractId == id);
        if (toDelete.Count() == 0)
        {
            return "NotFound";
        }

        _ = _contract.Remove(toDelete.Single());
        return "Deleted";
    }

    public async Task<bool> Update(Contract contract)
    {
        var existing = _contract.SingleOrDefault(x => x.ContractId == contract.ContractId);
        if (existing == null)
            return false;

        existing.PersonId = contract.PersonId;
        existing.PolicyId = contract.PolicyId;
        existing.ValidFrom = contract.ValidFrom;
        existing.ValidTo = contract.ValidTo;
        existing.Amount = contract.Amount;
        existing.Active = contract.Active;

        await Task.Delay(100).ConfigureAwait(false);
        return true;
    }
}
