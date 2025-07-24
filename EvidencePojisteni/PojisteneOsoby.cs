namespace EvidencePojisteni
{
    public class PojisteneOsoby
    {

        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Telefon { get; set; }
        public int Vek { get; set; }


        public PojisteneOsoby(string jmeno, string prijmeni, string telefon, int vek)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Telefon = telefon;
            Vek = vek;
        }
   
    
    
    }
}
