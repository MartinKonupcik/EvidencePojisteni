namespace EvidencePojisteni
{
    public class Policy
    {
        public Guid Id { get; set; }
        public  string InsuranceType { get; set; }
        public  string InsuranceName { get; set; }

        public Policy(string insuranceType, string insuranceName)
        {
            InsuranceType = insuranceType;
            InsuranceName = insuranceName;
        }
    }
}
