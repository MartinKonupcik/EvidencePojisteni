using EvidencePojisteni;
using Microsoft.Data.Sqlite;

var sprava = new Sprava();

Console.WriteLine("---------------------------------");
Console.WriteLine("Evidence Pojistenych");
Console.WriteLine("---------------------------------");

var choice = '0';
while (choice != '5')
{
    Console.WriteLine();
    Console.WriteLine("Vyberte si akci:");
    Console.WriteLine("1 - Přidat nového pojištěného");
    Console.WriteLine("2 - Vypsat všechny pojištěné");
    Console.WriteLine("3 - Vyhledat pojištěného podle jmena i přijmeni");
    Console.WriteLine("4 - Vyhledat pojištěného podle jmena nebo přijmeni");
    Console.WriteLine("5 - Konec");

    choice = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (choice)
    {
        case '1':
            sprava.PridatPojistence(); 
            break;

        case '2':
            sprava.VypisPojistencu();
            break;

        case '3':
            sprava.VyhledatPojistenceJmenoiPrijmeni();
            break;

            case '4':
                sprava.VyhledatPojistenceJmenoNeboPrijmeni();
            break;
        case '5':
            Console.WriteLine("Děkuji za použití aplikace.");
            break;

        default:
            Console.WriteLine("Neplatná volba. Zkuste to znovu.");
            break;
            



            using (var connection = new SqliteConnection("Data Source=evidence.db"))
            {
                connection.Open();

                
                var command = connection.CreateCommand();
                command.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Tabulka: {reader.GetString(0)}");
                }
            }
    }
}