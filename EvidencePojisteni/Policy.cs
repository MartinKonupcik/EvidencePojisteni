namespace EvidencePojisteni
{
    public class Policy
    {
        public Guid Id { get; set; }
        public enum Type
        {
            Life,
            Health,
            Property,
            Vehicle,
            Travel
        }
        public string Name { get; set; } = null!;
    }
}
