using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteni
{
    public class Sprava
    {
        private List<PojisteneOsoby> osoby = new List<PojisteneOsoby>();
  

        public void PridatPojsitene(PojisteneOsoby pojistenec)
        {
            osoby.Add(pojistenec);
            
        }


    }
}
