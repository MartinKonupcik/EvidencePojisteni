namespace EvidencePojisteni
{
    public static class OperatorKonzole
    {
        public static void VypisPojistence(PojistenaOsoba pojistenaOsoba)
        {
            Console.WriteLine(pojistenaOsoba.ToString());
        }

        public static void VypisPojistenych(List<PojistenaOsoba> pojisteneOsoby)
        {
            if (pojisteneOsoby.Count == 0)
            {
                Console.WriteLine("Zadny pojistenec neni evidovan.");
                return;
            }

            Console.WriteLine("Seznam pojistenych osob:");
            foreach (var pojistenec in pojisteneOsoby)
            {
                VypisPojistence(pojistenec);
            }
        }

        public static void PojistenciNenalezeni()
        {
            Console.WriteLine("Pojistenec nebyl nalezen.");
        }

        public static string NacteniNeprazdnehoStringu()
        {
            string? text = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Zadejte neprázný text!!!");
                text = Console.ReadLine();
            }
            return text.Trim();
        }
    }
}