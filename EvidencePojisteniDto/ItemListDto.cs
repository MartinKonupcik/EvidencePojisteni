using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniDto
{
    public class ItemListDto
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public string Person { get; set; }
        public decimal Amount { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
