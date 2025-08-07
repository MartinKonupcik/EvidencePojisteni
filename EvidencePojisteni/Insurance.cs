using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni;

public class Insurance
{
    
    [Key]
    public int Id { get; set; }
    public string Type { get; set; }
    public string Subject { get; set; }
    public decimal Amount { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }

    public bool Active { get; set; } = true;
    public int PersonNumber { get; set; }
}
