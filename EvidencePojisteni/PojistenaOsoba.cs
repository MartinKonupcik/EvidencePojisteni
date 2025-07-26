using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni
{
        public class PojistenaOsoba(string jmeno, string prijmeni, string telefon, int vek)
        {
            [Required(ErrorMessage = "Jméno je povinné")]
            public string Jmeno { get; } = jmeno;
            [Required(ErrorMessage = "Příjmení je povinné")]
            public string Prijmeni { get; } = prijmeni;
            public string Telefon { get; } = telefon;
            public int Vek { get; } = vek;
        }
    }
