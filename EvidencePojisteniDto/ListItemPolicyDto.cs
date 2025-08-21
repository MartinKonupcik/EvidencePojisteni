using System;

namespace EvidencePojisteniDto
{
    public class ListItemPolicyDto
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
        public string Name { get; set; }
    }
}
