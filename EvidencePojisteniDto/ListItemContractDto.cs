using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniDto
{
    public class ListItemContractDto
    {
        public Guid PolicyId { get; set; }
        public Guid ContractId { get; set; }
        public Guid PersonId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public decimal Amount { get; set; }
        public bool Active { get; set; } = true;
    }
}
