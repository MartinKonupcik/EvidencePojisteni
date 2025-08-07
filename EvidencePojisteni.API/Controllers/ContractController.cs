using EvidencePojisteni.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers;
/// <summary>
/// API controller for managing insurance records.
/// </summary>
[Route("Insurance")]
[ApiController]
public class ContractController(InsuranceService service) : ControllerBase
{
    /// <summary>
    /// Gets a specific insurance record by its ID.
    /// </summary>
    /// <param name="id">The ID of the insurance record.</param>
    /// <returns>
    /// The insurance record if found; otherwise, a 404 Not Found response.
    /// </returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Contract>> Get([FromRoute] int id)
    {
        var insurance = await service.Get(id);

        return insurance is null ? NotFound() : Ok(insurance);
    }

    /// <summary>
    /// Gets a list of all insurance records.
    /// </summary>
    /// <returns>
    /// An array of all insurance records.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<Contract[]>> GetList()
    {
        var allInsurance = await service.GetList();
        return Ok(allInsurance);
    }

    [HttpPost]
    public async Task New([FromBody] Contract insurance)
    {
        await service.Create(insurance);
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
