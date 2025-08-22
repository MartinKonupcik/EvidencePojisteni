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
        var policy = await service.Get(PolicyId);

        if (policy is null)
            return NotFound();

        var dto = new ListItemPolicyDto
        {
            Name = policy.Name,
            Type = policy.Type
        };

        return Ok(dto);
    }

    /// <summary>
    /// Gets a list of all policy records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ListItemPolicyDto[]>> GetList()
    {
        var allPolicies = await service.GetList();
        var dtos = allPolicies.Select(policy => new ListItemPolicyDto
        {
            Name = policy.Name,
            Type = policy.Type
        }).ToArray();
        return Ok(dtos);
    }

    /// <summary>
    /// Creates a new policy record.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> New([FromBody] EditPolicyDto policyDto)
    {
        var policy = new Policy
        {
            Id = Guid.NewGuid(), 
            Name = policyDto.Name,
            Type = policyDto.Type
        };
        await service.Create(policy);
        return CreatedAtAction(nameof(Get), new { PolicyId = policy.Id }, null);
    }

    /// <summary>
    /// Deletes a policy record by its ID.
    /// </summary>
    [HttpDelete("{PolicyId:Guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid PolicyId)
    {
        var result = await service.Delete(PolicyId);

        if (result == "Deleted")
        {
            return Ok();    
        }
       
        return NotFound();
    }

    /// <summary>
    /// Updates an existing policy record.
    /// </summary>
    [HttpPut("{PolicyId:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid PolicyId, [FromBody] UpdatePolicyDto policyDto)
    {
        var policy = new Policy
        {
            Id = PolicyId,
            Name = policyDto.Name,
            Type = policyDto.Type
        };

        var updated = await service.Update(PolicyId, policy);

        if (!updated)
            return NotFound();

        return NoContent();
    }
}
