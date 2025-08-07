using EvidencePojisteni.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers;
/// <summary>
/// API controller for managing contract records.
/// </summary>
[Route("Contract")]
[ApiController]
public class ContractController(ContractService service) : ControllerBase
{
    /// <summary>
    /// Gets a specific contract record by its ID.
    /// </summary>
    /// <param name="id">The ID of the contract record.</param>
    /// <returns>
    /// The contract record if found; otherwise, a 404 Not Found response.
    /// </returns>
    [HttpGet("{Contractid:Guid}")]
    public async Task<ActionResult<Contract>> Get([FromRoute] Guid id)
    {
        var contract = await service.Get(id);

        return contract is null ? NotFound() : Ok(contract);
    }

    /// <summary>
    /// Gets a list of all contract records.
    /// </summary>
    /// <returns>
    /// An array of all contract records.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<Contract[]>> GetList()
    {
        var allContracts = await service.GetList();
        return Ok(allContracts);
    }
    /// <summary>
    /// Creates a new contract record.
    /// </summary>
    /// <param name="contract">The contract object to create.</param>
    /// <returns>
    /// 201 Created if successful; otherwise, 400 Bad Request.
    /// </returns>
    [HttpPost]
    public async Task New([FromBody] Contract contract)
    {
        await service.Create(contract);
    }
    /// <summary>
    /// Deletes a contract record by its ID.
    /// </summary>
    /// <param name="contractID">The ID of the contract to delete.</param>
    /// <returns>
    /// 200 OK if deleted; otherwise, 404 Not Found.
    /// </returns>
    [HttpDelete("{Contractid:Guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid contractID)
    {
        var result = await service.Delete(contractID);

        if (result == "Deleted")
        {
            return Ok();
        }

        return NotFound();
    }
}
