using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Services
{
    public class PersonService
    {
        private List<Person> _person = new()
        {
           
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
        public async Task<ActionResult> Update(Guid personId, Person person)
        {
            var existingPerson = await Get(personId);
            if (existingPerson is null)
            {
                return new NotFoundResult();
            }
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Age = person.Age;
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);
            return new OkResult();
        }
    }
}
