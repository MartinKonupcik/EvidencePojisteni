using Microsoft.AspNetCore.Mvc;
using EvidencePojisteniDto;
namespace EvidencePojisteni.API.Services
{
    public class PersonService
    {
        private List<ListItemPersonDto> _person = new()
        {
           
        };

      public async Task<ListItemPersonDto?> Get(Guid personId)
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return _person.SingleOrDefault(p => p.PersonId == personId);
        }

        public async Task<ListItemPersonDto[]> GetList()
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return _person.ToArray();
        }

        public async Task Create(DetailPersonDto person)
        {
            
            if (person.PersonId == Guid.Empty)
            {
                person.PersonId = Guid.NewGuid();
            }

            var listItem = new ListItemPersonDto
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                ContractId = Guid.Empty,
                PolicyId = Guid.Empty
            };
            _person.Add(listItem);

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
        public async Task<ActionResult> Update(Guid personId, DetailPersonDto person)
        {
            var existingPerson = await Get(personId);
            if (existingPerson is null)
            {
                return new NotFoundResult();
            }
            var update = new ListItemPersonDto
            {
                PersonId = personId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                ContractId = existingPerson.ContractId,
                PolicyId = existingPerson.PolicyId,
            };
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);
            return new OkResult();
        }
    }
}
