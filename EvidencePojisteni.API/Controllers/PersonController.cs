using EvidencePojisteni.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers
{
    
    //stejne jako pojisteni napsat + pridat controller na policy + servicy + vše do Aj + api!!
        [Route("Person")]
        [ApiController]
    public class PersonController(PersonService service) : ControllerBase
    {
        /// <summary>
        /// Gets a specific person record by their person number.
        /// </summary>
        /// <param name="PersonId">The person number in the registry.</param>
        /// <returns>
        /// The person record if found; otherwise, a 404 Not Found response.
        /// </returns>
        [HttpGet("{PersonId:Guid}")]
        public async Task<ActionResult<Person>> Get([FromRoute] Guid PersonId)
        {
            var person = await service.Get(PersonId);

            return person is null ? NotFound() : Ok(person);
        }       

        /// <summary>
        /// Gets a list of all person records.
        /// </summary>
        /// <returns>
        /// An array of all person records.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<Person[]>> GetList()
        {
            var allPeople = await service.GetList();
            return Ok(allPeople);
        }

        /// <summary>
        /// Creates a new person record.
        /// </summary>
        /// <param name="person">The person object to create.</param>
        [HttpPost]
        public async Task New([FromBody] Person person)
        {
            await service.Create(person);
        }

        /// <summary>
        /// Deletes a person record by their person number.
        /// </summary>
        /// <param name="PersonId">The person number of the record to delete.</param>
        /// <returns>
        /// 200 OK if deleted; otherwise, 404 Not Found.
        /// </returns>
        [HttpDelete("{PersonId:Guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid PersonId)
        {
            var result = service.Delete(PersonId);

            if (result == "Deleted")
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("{PersonId:Guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid personId, [FromBody] Person person)
        {
            if (personId != person.PersonId)
            {
                return BadRequest("Person ID mismatch.");
            }
            var existingPerson = await service.Get(personId);
            if (existingPerson  is null)
            {
                return NotFound();
            }
            await service.Update(person);
            return NoContent();
        }
    }
}
