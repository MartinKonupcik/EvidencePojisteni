using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniDto
{
    public class ListItemPersonDto
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}
