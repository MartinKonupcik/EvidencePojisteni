using EvidencePojisteniDtos;

namespace EvidencePojisteni.API.Entities;

public class Person : Entity
{
    public Guid PolicyId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int Age { get; set; }
    public List <Guid> Contracts { get; set; }
    public Person() { }

    public Person(Guid id, DetailPersonDto dto)
    {
        Id = id;
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Phone = dto.Phone;
        Age = dto.Age;
        Contracts = dto.Contracts;
    }

    public void Update(DetailPersonDto dto)
    {
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Phone = dto.Phone;
        Age = dto.Age;
        Contracts = dto.Contracts;
    }

    public ListItemPersonDto GetListItem() => new()
    {
        PersonId = Id,
        FirstName = FirstName,
        LastName = LastName,
        Contracts = Contracts,
        PolicyId = PolicyId
    };

    public DetailPersonDto GetDetail() => new()
    {
        PersonId = Id,
        FirstName = FirstName,
        LastName = LastName,
        Phone = Phone,
        Age = Age,
        PolicyId = PolicyId
    };
}
