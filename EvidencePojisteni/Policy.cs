using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    public class Policy
    {
        public Guid Id { get; set; }
        public required string InsuranceType { get; set; }
        public required string InsuranceName { get; set; }
    }
}
