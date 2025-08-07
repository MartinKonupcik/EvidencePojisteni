using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni;

public class Contract
{
    
    [Key]
    public Guid ContractId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public decimal Amount { get; set; }
    public bool Active { get; set; } = true;
    public Guid PersonId { get; set; }
    public Guid PolicyId { get; set; }
}
