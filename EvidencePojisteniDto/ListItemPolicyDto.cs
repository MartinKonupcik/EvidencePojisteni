using System;

namespace EvidencePojisteniDto
{
    public class ListItemPolicyDto
    {
        public Guid ContractId { get; set; }
        public Guid PersonId { get; set; }
        public PolicyType Type { get; set; }
        public string Name { get; set; }
    }
}
