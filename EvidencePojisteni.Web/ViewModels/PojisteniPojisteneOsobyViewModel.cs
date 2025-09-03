namespace EvidencePojisteni.Web.Class
{
    using EvidencePojisteni.API.Entities;
    using EvidencePojisteniDto;

    public class PojisteniPojisteneOsobyViewModel
    {
        public Person Person { get; set; }
        public Policy Policy { get; set; }
        public Contract Contract { get; set; }
    }
}
// This class is used to represent the relationship between an insured person and their insurance policy.