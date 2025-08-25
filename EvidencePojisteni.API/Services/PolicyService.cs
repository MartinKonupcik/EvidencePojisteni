using EvidencePojisteni.API.Entities;
using EvidencePojisteniDto;
using System;

namespace EvidencePojisteni.API.Services
{
    public class PolicyService
    {
        private readonly List<ListItemPolicyDto> _policy = new();

        public async Task<ListItemPolicyDto?> Get(Guid policyId)
        {
            await Task.Delay(100).ConfigureAwait(false);

            return _policy.SingleOrDefault(p => p.PolicyId== policyId);
        }

        public async Task<ListItemPolicyDto[]> GetListItems()
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return _policy.ToArray();
        }

        public async Task Create(DetailPolicyDto policyDto)
        {
            var policy = new ListItemPolicyDto
            {
                PersonId = Guid.Empty,
                ContractId = Guid.Empty,
                Type = policyDto.Type,
                Name = policyDto.Name,
            };
            _policy.Add(policy);
            await Task.Delay(50).ConfigureAwait(false);
        }

        public async Task<bool> Delete(Guid id)
        {
            var toDelete = _policy.SingleOrDefault(x => x.PolicyId == id);
            if (toDelete == null)
            {
                return false;
            }
            _policy.Remove(toDelete);
            await Task.Delay(50).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> Update(Guid policyId, DetailPolicyDto policyDto)
        {
            var existing = _policy.SingleOrDefault(x => x.PolicyId == policyId);
            if (existing == null)
            {
                return false;
            }
            var updatedPolicy = new ListItemPolicyDto
            {
                PolicyId = policyId,
                PersonId = existing.PersonId,
                ContractId = existing.ContractId,
                Name = policyDto.Name,
                Type = policyDto.Type
            };
            await Task.Delay(50).ConfigureAwait(false);
            return true;
        }
    }
}
