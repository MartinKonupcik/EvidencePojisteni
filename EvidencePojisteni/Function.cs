namespace EvidencePojisteni;


   public class Function
    {
        private List<Person> people = new();

        public void AddPerson()
        {
            Console.WriteLine("Enter the person's first name:");
            var firstName = ConsoleOperator.ReadNonEmptyString();

            Console.WriteLine("Enter the person's last name:");
            var lastName = ConsoleOperator.ReadNonEmptyString();

            Console.WriteLine("Enter the person's phone number:");
            var phone = ConsoleOperator.ReadNonEmptyString();

            Console.WriteLine("Enter the person's age (0-120):");
            int age;
            while (!int.TryParse(ConsoleOperator.ReadNonEmptyString(), out age) || age < 0 || age > 120)
            {
                Console.WriteLine("Invalid age. Please enter an age between 0 and 120:");
            }

            var newPerson = new Person(firstName, lastName, phone, age);
            people.Add(newPerson);

            Console.WriteLine("Person was successfully added.");
        }

        public void ListPeople()
        {
            if (people.Count == 0)
            {
                ConsoleOperator.NoPeopleFound();
                return;
            }

            ConsoleOperator.ListPeople(people);
        }

        public void FindPersonByFirstAndLastName()
        {
            Console.WriteLine("Enter first name:");
            var searchFirstName = ConsoleOperator.ReadNonEmptyString();
            Console.WriteLine("Enter last name:");
            var searchLastName = ConsoleOperator.ReadNonEmptyString();
            var foundPeople = people.Where(p => p.FirstName.Equals(searchFirstName, StringComparison.OrdinalIgnoreCase) && p.LastName.Equals(searchLastName, StringComparison.OrdinalIgnoreCase)).ToList();
            HandleOutput(foundPeople);
        }

        public void FindPersonByFirstOrLastName()
        {
            Console.WriteLine("1- First name");
            Console.WriteLine("2- Last name");
            var choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    Console.WriteLine();
                    Console.WriteLine("Enter first name:");
                    var searchFirstName = ConsoleOperator.ReadNonEmptyString();
                    var foundByFirstName = people.Where(p => p.FirstName == searchFirstName).ToList();
                    HandleOutput(foundByFirstName);
                    break;
                case '2':
                    Console.WriteLine();
                    Console.WriteLine("Enter last name:");
                    var searchLastName = ConsoleOperator.ReadNonEmptyString();
                    var foundByLastName = people.Where(p => p.LastName == searchLastName).ToList();
                    HandleOutput(foundByLastName);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        public void HandleOutput(List<Person> foundPeople)
        {
            if (foundPeople.Count > 1)
            {
                ConsoleOperator.ListPeople(foundPeople);
            }
            else if (foundPeople.Count == 1)
            {
                ConsoleOperator.ShowPerson(foundPeople.Single());
            }
            else
            {
                ConsoleOperator.NoPeopleFound();
            }
        }

        public void AddInsurance()
        {
            Console.WriteLine("Enter the person's number:");
            int number;
            int.TryParse(Console.ReadLine(), out number);
            var person = people.FirstOrDefault(p => p.PersonNumber == number);
            if (person == null)
            {
                ConsoleOperator.NoPeopleFound();
                return;
            }

            Console.WriteLine("Enter insurance type:");
            var type = ConsoleOperator.ReadNonEmptyString();
            Console.WriteLine("Enter insurance subject:");
            var subject = ConsoleOperator.ReadNonEmptyString();
            Console.WriteLine("Enter amount:");
            var amount = decimal.Parse(ConsoleOperator.ReadNonEmptyString());
            Console.WriteLine("Valid from (yyyy-mm-dd):");
            var validFrom = DateTime.Parse(ConsoleOperator.ReadNonEmptyString());
            Console.WriteLine("Valid to (yyyy-mm-dd):");
            var validTo = DateTime.Parse(ConsoleOperator.ReadNonEmptyString());

            var insurance = new Insurance { Type = type, Subject = subject, Amount = amount, ValidFrom = validFrom, ValidTo = validTo };
            person.Insurances.Add(insurance);
            Console.WriteLine("Insurance added.");
        }
    }
}


