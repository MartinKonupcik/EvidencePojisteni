using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni
{
    public class PojisteneOsoby
    {
        [Required(ErrorMessage = "Jméno je povinné")]
        public string Jmeno { get; set; }
        [Required(ErrorMessage = "Příjmení je povinné")]
        public string Prijmeni { get; set; }
        [Required(ErrorMessage = "Telefon je povinný")]
        public string Telefon { get; set; }
        [Range(0, 120, ErrorMessage = "Věk musí být mezi 0 a 120 lety")]
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
