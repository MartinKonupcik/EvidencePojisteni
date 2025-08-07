using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace EvidencePojisteni.API.Services
{
    public class PolicyService
    {
        private List<Policy> _policy = new()
        {
            
        };

        public async Task<Policy?> Get(Guid policyId)
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return _policy.SingleOrDefault(p => p.Id == policyId);
        }

        public async Task<Policy[]> GetList()
        {
            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);

            return [.. _policy];
        }

        public async Task Create(Policy policy)
        {
            // Assign a new Guid if not already set
            if (policy.Id == Guid.Empty)
            {
                policy.Id = Guid.NewGuid();
            }

            _policy.Add(policy);

            // Simulate async operation
            await Task.Delay(100).ConfigureAwait(false);
        }

        public async Task<string> Delete(Guid id)
        {
            var toDelete = _policy.Where(x => x.Id == id);
            if (toDelete.Count() == 0)
            {
                return "NotFound";
            }

            _ = _policy.Remove(toDelete.Single());
            return "Deleted";
        }
        public async Task<bool> Update(Guid policyId, Policy policy)
        {
            var existing = _policy.SingleOrDefault(x => x.Id == policyId);
            if (existing == null)
                return false;

            existing.Name = policy.Name;
            
            // ... other properties

            await Task.Delay(100).ConfigureAwait(false);
            return true;
        }
    }
}
