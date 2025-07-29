using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvidencePojisteni
{
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
}
