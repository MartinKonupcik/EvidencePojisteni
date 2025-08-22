using System;

namespace EvidencePojisteniDto
{
    public class ListItemPolicyDto
    {
        public Guid Id { get; set; }
        public PolicyType.Type Type { get; set; }
        public string Name { get; set; }
    }
}
