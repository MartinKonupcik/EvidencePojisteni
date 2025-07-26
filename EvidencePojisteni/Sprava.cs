using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    public class Sprava
    {
        private List<PojistenaOsoba> osoby = new List<PojistenaOsoba>();
  
        public void PridatPojistence()
        {
            Console.WriteLine("Zadejte jméno pojisteneho:");
            string jmeno = Console.ReadLine();

            Console.WriteLine("Zadejte příjmení pojisteneho:");
            string prijmeni = Console.ReadLine();

            Console.WriteLine("Zadejte telefon pojisteneho:");
            string telefon = Console.ReadLine();

            Console.WriteLine("Zadejte věk pojisteneho (0-120):");
            int vek;
            while (!int.TryParse(Console.ReadLine(), out vek) || vek < 0 || vek > 120)
            {
                Console.WriteLine("Neplatný věk. Zadejte věk mezi 0 a 120:");
            }

            var novyPojistenec = new PojistenaOsoba(jmeno, prijmeni, telefon, vek);
            osoby.Add(novyPojistenec); 

            Console.WriteLine("Pojistenec byl úspěšně přidán.");
        }

        public void VypisPojistene()
        {
            if (osoby.Count == 0)
            {
                Console.WriteLine("Zadny pojistenec neni evidovan.");
                return;
            }
            Console.WriteLine("Seznam pojistenych osob:");
            foreach (var pojistenec in osoby)
            {
                Console.WriteLine($"{pojistenec.Jmeno} {pojistenec.Prijmeni}  {pojistenec.Telefon}  {pojistenec.Vek}");
            }
        }

        public void VyhledatPojistence()
        {
            Console.WriteLine("Podle čeho chcete pojistence najit?");
            Console.WriteLine("1- Jmeno");
            Console.WriteLine("2- Prijmeni");   
            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    Console.WriteLine("Zadejte jméno:");
                    string hledaneJmeno = Console.ReadLine()?.Trim();
                    var nalezeniPodleJmena = osoby.Where(o => o.Jmeno.Equals(hledaneJmeno, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (nalezeniPodleJmena.Count > 0)
                    {
                        Console.WriteLine("Nalezeni pojistenci:");
                        foreach (var pojistenec in nalezeniPodleJmena)
                        {
                            Console.WriteLine($"{pojistenec.Jmeno} {pojistenec.Prijmeni} {pojistenec.Telefon} {pojistenec.Vek}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Žádný pojištěný s tímto jménem nebyl nalezen.");
                    }
                    break;
                case '2':
                    Console.WriteLine("Zadejte příjmení:");
                    string hledanePrijmeni = Console.ReadLine()?.Trim();
                    var nalezeniPodlePrijmeni = osoby.Where(o => o.Prijmeni.Equals(hledanePrijmeni, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (nalezeniPodlePrijmeni.Count > 0)
                    {
                        Console.WriteLine("Nalezeni pojistenci:");
                        foreach (var pojistenec in nalezeniPodlePrijmeni)
                        {
                            Console.WriteLine($"{pojistenec.Jmeno} {pojistenec.Prijmeni} {pojistenec.Telefon} {pojistenec.Vek}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Žádný pojištěný s tímto příjmením nebyl nalezen.");
                    }
                    break;
                default:
                    Console.WriteLine("Neplatná volba. Zkuste to znovu.");
                    break;
            }
        }
    }
}
