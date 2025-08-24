using EvidencePojisteniDto;

namespace EvidencePojisteni.API.Entities;

public class Policy : Entity
{
    public PolicyType Type { get; set; }
    public string Name { get; set; } = null!;
}

