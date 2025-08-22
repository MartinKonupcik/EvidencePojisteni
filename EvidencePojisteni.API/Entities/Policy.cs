using EvidencePojisteniDto;

namespace EvidencePojisteni
{
    public class Policy
    {
        public Guid Id { get; set; }
        public PolicyType Type { get; set; }
        public string Name { get; set; } = null!;
    }
}
