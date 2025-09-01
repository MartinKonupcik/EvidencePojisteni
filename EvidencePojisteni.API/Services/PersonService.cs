using EvidencePojisteni.API.Entities;
using EvidencePojisteniDtos;

namespace EvidencePojisteni.API.Services;

public class PersonService
{
    private List<Person> _personList =
    [
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "Jan",
            LastName = "Novák",
            Phone = "123456789",
            Age = 30,
            Contracts = [Guid.NewGuid()],
            PolicyId = Guid.NewGuid()
        },
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "Petr",
            LastName = "Svoboda",
            Phone = "987654321",
            Age = 45,
            Contracts = [Guid.NewGuid()],
            PolicyId = Guid.NewGuid()
        }
];
        public async Task<DetailPersonDto?> Get(Guid personId)
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return _personList.SingleOrDefault(p => p.Id == personId)?.GetDetail();
    }

    public async Task<ListItemPersonDto[]> GetList()
    {
        // Simulate async operation
        await Task.Delay(100).ConfigureAwait(false);

        return [.. _personList.Select(p => p.GetListItem())];
    }

    public async Task Create(DetailPersonDto person)
    {
        _personList.Add(new Person(Guid.NewGuid(), person));
        await Task.Delay(100).ConfigureAwait(false);
    }

    public async Task<string> Delete(Guid personId)
    {
        if (_personList.Any(c => c.Id == personId))
        {
            _ = _personList.RemoveAll(c => c.Id == personId);
            return "Deleted";
        }
        return "Not Found";
    }
    public async Task<bool> Update(Guid personId, DetailPersonDto personDto)
    {
        _personList.FirstOrDefault(c => c.Id == personId)?.Update(personDto);
        await Task.Delay(100).ConfigureAwait(false);
        return true;
    }
}
