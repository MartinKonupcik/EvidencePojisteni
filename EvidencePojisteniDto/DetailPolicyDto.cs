using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniDto
{
    public class DetailPolicyDto
    {
        public Guid PolicyId { get; set; }
        public PolicyType Type { get; set; }
        public string Name { get; set; }
    }
}
