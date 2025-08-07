using EvidencePojisteni;
using Microsoft.Data.Sqlite;

var function = new Function();

Console.WriteLine("---------------------------------");
Console.WriteLine("Insured Persons Registry");
Console.WriteLine("---------------------------------");


var choice = '0';
while (choice != '5')
{
    Console.WriteLine();
    Console.WriteLine("Select an action:");
    Console.WriteLine("1 - Add a new insured person");
    Console.WriteLine("2 - List all insured persons");
    Console.WriteLine("3 - Find insured person by first and last name");
    Console.WriteLine("4 - Find insured person by first or last name");
    Console.WriteLine("5 - Exit");

    choice = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (choice)
    {
        case '1':
            manager.AddPerson();
            break;

        case '2':
            manager.ListPeople();
            break;

        case '3':
            manager.FindPersonByFirstAndLastName();
            break;

        case '4':
            manager.FindPersonByFirstOrLastName();
            break;

        case '5':
            Console.WriteLine("Thank you for using the application.");
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    using (var connection = new SqliteConnection("Data Source=registry.db"))
    {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"Table: {reader.GetString(0)}");
            }
        }
    }
}