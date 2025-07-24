using EvidencePojisteni;

List<PojisteneOsoby> seznamPojistencu = new List<PojisteneOsoby>();
Console.WriteLine("---------------------------------");
Console.WriteLine("Evidence Pojistenych");
Console.WriteLine("---------------------------------");
Console.WriteLine();
Console.WriteLine("Vyberte si akci:");
var choice = '0';
while (choice != '5')
{
    Console.WriteLine();
    Console.WriteLine("1- Pridat noveho pojisteneho");
    Console.WriteLine("2- Vypsat vsechny pojistene");
    Console.WriteLine("3- Vyhledat pojisteneho");
    Console.WriteLine("4- Konec");
    
    choice = Console.ReadKey().KeyChar;
    Console.WriteLine();
    switch
        (choice)
    {
        case '1':
          
            break;

        case '2':
           
            break;

        case '3':
         
            break;

        case '4':
            Console.WriteLine("Děkuji za použití aplikace");
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}