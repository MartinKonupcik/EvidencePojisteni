namespace EvidencePojisteni.API.Services
{
    public class PersonService
    {
        private List<Person> _person = new()
        {
            new Person("Jan", "Novák", "123456789", 30)
            {
                PersonId = Guid.NewGuid()
            },

            new Person("Petr", "Svoboda", "987654321", 45)
            {
                PersonId = Guid.NewGuid()
            }
        };

      public async Task<Person?> Get(Guid personId)
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return _person.SingleOrDefault(p => p.PersonId == personId);
        }

        public async Task<Person[]> GetList()
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return [.. _person];
        }

        public async Task Create(Person person)
        {
            // Assign a new Guid if not already set
            if (person.PersonId == Guid.Empty)
            {
                person.PersonId = Guid.NewGuid();
            }

            _person.Add(person);

            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);
        }

        public string Delete(Guid personId)
        {
            var toDelete = _person.Where(x => x.PersonId == personId);
            if (toDelete.Count() == 0)
            {
                return "NotFound";
            }
            _ = _person.Remove(toDelete.Single());
            return "Deleted";
        }
    }
}
