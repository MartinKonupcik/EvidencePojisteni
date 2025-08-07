using EvidencePojisteni.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers;
/// <summary>
/// API controller for managing insurance records.
/// </summary>
[Route("pojisteni")]
[ApiController]
public class InsuranceController(PojisteniService service) : ControllerBase
{
    /// <summary>
    /// Gets a specific insurance record by its ID.
    /// </summary>
    /// <param name="id">The ID of the insurance record.</param>
    /// <returns>
    /// The insurance record if found; otherwise, a 404 Not Found response.
    /// </returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Insurance>> Get([FromRoute] int id)
    {
        var pojisteni = await service.Get(id);

        return pojisteni is null ? NotFound() : Ok(pojisteni);
    }

    /// <summary>
    /// Gets a list of all insurance records.
    /// </summary>
    /// <returns>
    /// An array of all insurance records.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<Insurance[]>> GetList()
    {
        var allPojisteni = await service.GetList();
        return Ok(allPojisteni);
    }

    [HttpPost]
    public async Task New([FromBody] Insurance pojisteni)
    {
        await service.Create(pojisteni);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var result = await service.Delete(id);

        if (result == "Deleted")
        {
            return Ok();
        }

        return NotFound();
    }
}
