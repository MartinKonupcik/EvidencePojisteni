using System;

namespace EvidencePojisteniDto
{
    public class UpdatePersonDto
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}
