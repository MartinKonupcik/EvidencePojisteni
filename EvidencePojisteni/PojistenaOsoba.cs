using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni
{
    public class PojistenaOsoba(string jmeno, string prijmeni, string telefon, int vek)
    {
        public int CisloPojistence { get; set; } = new Random().Next(1000, 9999);

        [Required(ErrorMessage = "Jméno je povinné")]
        public string Jmeno { get; } = jmeno;
        [Required(ErrorMessage = "Příjmení je povinné")]
        public string Prijmeni { get; } = prijmeni;
        public string Telefon { get; } = telefon;
        public int Vek { get; } = vek;

        public override string ToString()
        {
            return $"{CisloPojistence}, {Jmeno} {Prijmeni}, Telefon: {Telefon}, Vek: {Vek}";
        }
    }
}
