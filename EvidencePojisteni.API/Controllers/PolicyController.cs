using EvidencePojisteni.API.Services;
using EvidencePojisteniDto;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers;

[Route("Policy")]
[ApiController]
public class PolicyController(PolicyService service) : ControllerBase
{
    /// <summary>
    /// Gets a specific policy record by its ID.
    /// </summary>
    [HttpGet("{PolicyId:Guid}")]
    public async Task<ActionResult<ListItemPolicyDto>> Get([FromRoute] Guid PolicyId)
    {
        var dto = await service.Get(PolicyId);
        if (dto is null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

    /// <summary>
    /// Gets a list of all policy records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ListItemPolicyDto[]>> GetList()
    {
        var dtos = await service.GetListItems();
        return Ok(dtos);
    }

    /// <summary>
    /// Creates a new policy record.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> New([FromBody] DetailPolicyDto policyDto)
    {
        await service.Create(policyDto);
        return CreatedAtAction(nameof(Get), new { Id = policyDto.PolicyId }, null);

    }

    /// <summary>
    /// Deletes a policy record by its ID.
    /// </summary>
    [HttpDelete("{PolicyId:Guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid PolicyId)
    {
        var deleted = await service.Delete(PolicyId);
        if (deleted)
        {
            return Ok();
        }
        return NotFound();
    }

    /// <summary>
    /// Updates an existing policy record.
    /// </summary>
    [HttpPut("{PolicyId:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid PolicyId, [FromBody] DetailPolicyDto policyDto)
    {
        var updated = await service.Update(PolicyId, policyDto);
        if (!updated) { 
            return NotFound();
        }
        return NoContent();
    }
}
