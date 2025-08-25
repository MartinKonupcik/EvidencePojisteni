using EvidencePojisteni.API.Services;
using EvidencePojisteniDto;
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
    [HttpGet("{ContractId:Guid}")]
    public async Task<ActionResult<ListItemContractDto>> Get([FromRoute] Guid ContractId)
    {
        var contract = await service.Get(ContractId);
        if (contract is null)
            return NotFound();
        return Ok(contract);
    }

    /// <summary>
    /// Gets a list of all contract records.
    /// </summary>
    /// <returns>
    /// An array of all contract records.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<ListItemContractDto[]>> GetList()
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
    public async Task<IActionResult> New([FromBody] DetailContractDto contractDto)
    {
        if (contractDto is null)
            return BadRequest("Contract data is required.");

        await service.Create(contractDto);
        return StatusCode(201);
    }

    /// <summary>
    /// Deletes a contract record by its ID.
    /// </summary>
    /// <param name="contractID">The ID of the contract to delete.</param>
    /// <returns>
    /// 200 OK if deleted; otherwise, 404 Not Found.
    /// </returns>
    [HttpDelete("{ContractId:Guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid ContractId)
    {
        var result = await service.Delete(ContractId);
        if (result == "Deleted")
        {
            return Ok();
        }
        return NotFound();
    }

    /// <summary>
    /// Updates a contract record by its ID.
    /// </summary>
    /// <param name="contractId">The ID of the contract to update.</param>
    /// <param name="UpdateContractDto">The updated contract object.</param>
    /// <returns>
    /// 204 No Content if successful; otherwise, 400 Bad Request or 404 Not Found.
    /// </returns>
    [HttpPut("{ContractId:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid ContractId, [FromBody] DetailContractDto contractDto)
    {
        var updated = await service.Update(ContractId, contractDto);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }
}
