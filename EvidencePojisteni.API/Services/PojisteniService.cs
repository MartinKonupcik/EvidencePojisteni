namespace EvidencePojisteni.API.Services;

public class PojisteniService
{
    private List<Pojisteni> _pojisteni =
    [
        new()
        {
            Id = 0,
            Typ = "Životní pojištění",
            Predmet = "Život",
            Castka = 1000000,
            PlatnostOd = DateTime.Now.AddYears(-1),
            PlatnostDo = DateTime.Now.AddYears(9),
            CisloPojistence = 123456789
        },
        new()
        {
            Id = 1,
            Typ = "Úrazové pojištění",
            Predmet = "Úraz",
            Castka = 500000,
            PlatnostOd = DateTime.Now.AddYears(-2),
            PlatnostDo = DateTime.Now.AddYears(8),
            CisloPojistence = 987654321
        }
    ];

    public async Task<Pojisteni?> Get(int id)
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return _pojisteni.SingleOrDefault(p => p.Id == id);
    }

    public async Task<Pojisteni[]> GetList()
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return [.. _pojisteni];
    }

    public async Task Create(Pojisteni pojisteni)
    {
        for (var i = 0; i <= _pojisteni.Count; i++)
        {
            if (!_pojisteni.Any(x => x.Id == i))
            {
                pojisteni.Id = i;
                break;
            }
        }

        _pojisteni.Add(pojisteni);
    }

    public async Task<string> Delete(int id)
    {
        var toDelete = _pojisteni.Where(x => x.Id == id);
        if (toDelete.Count() == 0)
        {
            return "NotFound";
        }

        _ = _pojisteni.Remove(toDelete.Single());
        return "Deleted";
    }
}
