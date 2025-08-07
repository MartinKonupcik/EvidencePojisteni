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
        /// <param name="PersonNumber">The person number in the registry.</param>
        /// <returns>
        /// The person record if found; otherwise, a 404 Not Found response.
        /// </returns>
        [HttpGet("{PersonNumber:int}")]
        public async Task<ActionResult<Person>> Get([FromRoute] int PersonNumber)
        {
            var person = await service.Get(PersonNumber);

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
        /// <param name="PersonNumber">The person number of the record to delete.</param>
        /// <returns>
        /// 200 OK if deleted; otherwise, 404 Not Found.
        /// </returns>
        [HttpDelete("{PersonNumber:int}")]
        public async Task<ActionResult> Delete([FromRoute] int PersonNumber)
        {
            var result = await service.Delete(PersonNumber);

            if (result == "Deleted")
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
