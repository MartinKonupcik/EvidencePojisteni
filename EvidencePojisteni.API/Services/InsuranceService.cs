namespace EvidencePojisteni.API.Services;

public class InsuranceService
{
    private List<Contract> _insurance =
    [
        new()
        {
            Id = 0,
            Type = "Life Insurance",
            Subject = "Life",
            Amount = 1000000,
            ValidFrom = DateTime.Now.AddYears(-1),
            ValidTo = DateTime.Now.AddYears(9),
            PersonNumber = 123456789
        },
        new()
        {
            Id = 1,
            Type = "Accident Insurance",
            Subject = "Accident",
            Amount = 500000,
            ValidFrom = DateTime.Now.AddYears(-2),
            ValidTo = DateTime.Now.AddYears(8),
            PersonNumber = 987654321
        }
    ];

    public async Task<Contract?> Get(int id)
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return _insurance.SingleOrDefault(p => p.Id == id);
    }

    public async Task<Contract[]> GetList()
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return [.. _insurance];
    }

    public async Task Create(Contract insurance)
    {
        for (var i = 0; i <= _insurance.Count; i++)
        {
            if (!_insurance.Any(x => x.Id == i))
            {
                insurance.Id = i;
                break;
            }
        }

        _insurance.Add(insurance);
    }

    public async Task<string> Delete(int id)
    {
        var toDelete = _insurance.Where(x => x.Id == id);
        if (toDelete.Count() == 0)
        {
            return "NotFound";
        }

        _ = _insurance.Remove(toDelete.Single());
        return "Deleted";
    }
}
