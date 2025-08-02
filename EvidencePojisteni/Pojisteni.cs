using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EvidencePojisteni;

public class Pojisteni
{
    [Key]
    public int Id { get; set; }
    public string Typ { get; set; }
    public string Predmet { get; set; }
    public decimal Castka { get; set; }
    public DateTime PlatnostOd { get; set; }
    public DateTime PlatnostDo { get; set; }
    public int CisloPojistence { get; set; }

    [ForeignKey(nameof(CisloPojistence))]
    public PojistenaOsoba PojistenaOsoba { get; set; }
}
