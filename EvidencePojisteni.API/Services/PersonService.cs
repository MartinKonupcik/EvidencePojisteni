namespace EvidencePojisteni.API.Services
{
    public class PersonService
    {
        private List<Person> _person = new()
        {
            new Person("Jan", "Novák", "123456789", 30)
            {
                PersonNumber = 0
            },

            new Person("Petr", "Svoboda", "987654321", 45)
            {
                PersonNumber = 1
            }
        };

        public async Task<Person?> Get(int personNumber)
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return _person.SingleOrDefault(p => p.PersonNumber == personNumber);
        }

        public async Task<Person[]> GetList()
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return [.. _person];
        }

        public async Task Create(Person person)
        {
            for (var i = 0; i <= _person.Count; i++)
            {
                if (!_person.Any(x => x.PersonNumber == i))
                {
                    person.PersonNumber = i;
                    break;
                }
            }

            _person.Add(person);
        }

        public async Task<string> Delete(int personNumber)
        {
            var toDelete = _person.Where(x => x.PersonNumber == personNumber);
            if (toDelete.Count() == 0)
            {
                return "NotFound";
            }
            _ = _person.Remove(toDelete.Single());
            return "Deleted";
        }
    }
}
