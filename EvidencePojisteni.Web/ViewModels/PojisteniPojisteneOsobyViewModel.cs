namespace EvidencePojisteni.Web.Class
{
    public class PojisteniPojisteneOsobyViewModel
    {
        public required Person Osoba { get; set; }
        public required Contract Pojisteni { get; set; }
    }
}
// This class is used to represent the relationship between an insured person and their insurance policy.