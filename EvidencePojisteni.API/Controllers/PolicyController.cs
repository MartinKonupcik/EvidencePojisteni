using EvidencePojisteni.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers
{
    [Route("Policy")]
    [ApiController]
    public class PolicyController(PolicyService service) : ControllerBase
    {
        /// <summary>
        /// Gets a specific policy record by its ID.
        /// </summary>
        /// <param name="PolicyId">The ID of the policy record.</param>
        /// <returns>
        /// The policy record if found; otherwise, a 404 Not Found response.
        /// </returns>
        [HttpGet("{PolicyId:Guid}")]
        public async Task<ActionResult<Policy>> Get([FromRoute] Guid PolicyId)
        {
            var policy = await service.Get(PolicyId);

            return policy is null ? NotFound() : Ok(policy);
        }

        /// <summary>
        /// Gets a list of all policy records.
        /// </summary>
        /// <returns>
        /// An array of all policy records.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<Policy[]>> GetList()
        {
            var allPolicies = await service.GetList();
            return Ok(allPolicies);
        }

        /// <summary>
        /// Creates a new policy record.
        /// </summary>
        /// <param name="policy">The policy object to create.</param>
        [HttpPost]
        public async Task New([FromBody] Policy policy)
        {
            await service.Create(policy);
        }

        /// <summary>
        /// Deletes a policy record by its ID.
        /// </summary>
        /// <param name="PolicyId">The ID of the policy to delete.</param>
        /// <returns>
        /// 200 OK if deleted; otherwise, 404 Not Found.
        /// </returns>
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
        ///  Updates an existing policy record.
        /// </summary>
        /// <param name="PolicyId">The ID of the policy to update.</param>
        /// <param name="policy">The updated policy object.</param>
        /// <returns>
        /// 204 No Content if updated; otherwise, 404 Not Found.
        /// </returns>
        [HttpPut("{PolicyId:Guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid PolicyId, [FromBody] Policy policy)
        {
            if (PolicyId != policy.Id)
            {
                return BadRequest("Policy ID mismatch.");
            }
            var updated = await service.Update(PolicyId, policy);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
