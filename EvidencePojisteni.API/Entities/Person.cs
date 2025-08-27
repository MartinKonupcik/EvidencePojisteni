using EvidencePojisteniDtos;

namespace EvidencePojisteni.API.Entities;

public class Person : Entity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int Age { get; set; }
    public List <Guid> ContractId { get; set; }
    public Person() { }

    public Person(Guid id, DetailPersonDto dto)
    {
        Id = id;
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Phone = dto.Phone;
        Age = dto.Age;
    }

    public void Update(DetailPersonDto dto)
    {
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Phone = dto.Phone;
        Age = dto.Age;
    }

    public ListItemPersonDto GetListItem() => new()
    {
        FirstName = FirstName,
        LastName = LastName,
        ContractId = ContractId,
    };

    public DetailPersonDto GetDetail() => new()
    {
        PersonId = Id,
        FirstName = FirstName,
        LastName = LastName,
        Phone = Phone,
        Age = Age
    };
}
