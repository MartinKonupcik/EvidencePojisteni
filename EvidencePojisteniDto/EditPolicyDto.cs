using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniDto
{
    public class EditPolicyDto
    {
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
