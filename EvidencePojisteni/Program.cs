using EvidencePojisteni;

var sprava = new Sprava();

Console.WriteLine("---------------------------------");
Console.WriteLine("Evidence Pojistenych");
Console.WriteLine("---------------------------------");

char choice = '0';
while (choice != '4')
{
    Console.WriteLine();
    Console.WriteLine("Vyberte si akci:");
    Console.WriteLine("1 - Přidat nového pojištěného");
    Console.WriteLine("2 - Vypsat všechny pojištěné");
    Console.WriteLine("3 - Vyhledat pojištěného");
    Console.WriteLine("4 - Konec");

    choice = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (choice)
    {
        case '1':
            sprava.PridatPojistence(); 
            break;

        case '2':
            sprava.VypisPojistene();
            break;

        case '3':
            sprava.VyhledatPojistene();
            break;

        case '4':
            Console.WriteLine("Děkuji za použití aplikace.");
            break;

        default:
            Console.WriteLine("Neplatná volba. Zkuste to znovu.");
            break;
    }
}