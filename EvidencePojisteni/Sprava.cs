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

        public void VypisPojistencu()
        { 
            if (osoby.Count == 0)
            {
              OperatorKonzole.PojistenciNenalezeni();
                return;
            }
            OperatorKonzole.VypisPojistenych(osoby);
        }
       
        public void VyhledatPojistenceJmenoiPrijmeni()
        {
            Console.WriteLine("Zadejte Jmeno");
            string hledaneJmeno = Console.ReadLine()?.Trim();
            Console.WriteLine("Zadejte Příjmení");
            string hledanePrijmeni = Console.ReadLine()?.Trim();
            var nalezeniPojistenci = osoby.Where(o => o.Jmeno.Equals(hledaneJmeno, StringComparison.OrdinalIgnoreCase) && o.Prijmeni.Equals(hledanePrijmeni, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var pojistenec in nalezeniPojistenci)
            {
                Console.WriteLine($"{pojistenec.Jmeno} {pojistenec.Prijmeni} {pojistenec.Telefon} {pojistenec.Vek}");
            }
        }

        public void VyhledatPojistenceJmenoNeboPrijmeni()
        {
            Console.WriteLine("1- Jmeno");
            Console.WriteLine("2- Příjmení");
            var volba = Console.ReadKey().KeyChar;
            switch (volba)
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
            
