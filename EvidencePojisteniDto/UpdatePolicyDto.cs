using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniDto
{
    public class UpdatePolicyDto
    {
        public Guid Id { get; set; }
        public PolicyType.Type Type { get; set; }
        public string Name { get; set; }
    }
}
