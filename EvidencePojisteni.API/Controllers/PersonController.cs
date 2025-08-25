using EvidencePojisteni.API.Services;
using EvidencePojisteniDto;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers;

[Route("Person")]
[ApiController]
public class PersonController(PersonService service) : ControllerBase
{
    /// <summary>
    /// Gets a specific person record by their ID.
    /// </summary>
    [HttpGet("{PersonId:Guid}")]
    public async Task<ActionResult<ListItemPersonDto>> Get([FromRoute] Guid PersonId)
    {
        var person = await service.Get(PersonId);
        if (person is null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    /// <summary>
    /// Gets a list of all person records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ListItemPersonDto[]>> GetList()
    {
        var dtos = await service.GetList();
        return Ok(dtos);
    }

    /// <summary>
    /// Creates a new person record.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> New([FromBody] DetailPersonDto personDto)
    {
        await service.Create(personDto);
        return CreatedAtAction(nameof(Get), new { PersonId = personDto.PersonId }, null);
    }

    /// <summary>
    /// Deletes a person record by their ID.
    /// </summary>
    [HttpDelete("{PersonId:Guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid PersonId)
    {
        var result = await Task.Run(() => service.Delete(PersonId));
        if (result == "Deleted")
        {
            return Ok();
        }
        return NotFound();
    }

    /// <summary>
    /// Updates a person record by their ID.
    /// </summary>
    [HttpPut("{PersonId:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid PersonId, [FromBody] DetailPersonDto personDto)
    {
        var updateResult = await service.Update(PersonId, personDto);
        return updateResult;
    }
}
