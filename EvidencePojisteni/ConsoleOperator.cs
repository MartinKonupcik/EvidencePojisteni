namespace EvidencePojisteni;

public static class ConsoleOperator
{
        public static void ShowPerson(Person person)
        {
            Console.WriteLine(person.ToString());
        }

        public static void ListPeople(List<Person> people)
        {
            if (people.Count == 0)
            {
                Console.WriteLine("No insured person is registered.");
                return;
            }

            Console.WriteLine("List of insured persons:");
            foreach (var person in people)
            {
                ShowPerson(person);
            }
        }

        public static void NoPeopleFound()
        {
            Console.WriteLine("No insured person was found.");
        }

        public static string ReadNonEmptyString()
        {
            var text = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Please enter a non-empty text!");
                text = Console.ReadLine();
            }

            return text.Trim();
        }
    }
