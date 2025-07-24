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

        public void VypisPojistene()
        {
            if (osoby.Count == 0)
            {
                Console.WriteLine("Zadny pojistenec neni evidovan.");
                return;
            }
            Console.WriteLine("Seznam pojistenych osob:");
            foreach (var pojistenec in osoby)
            {
                Console.WriteLine($"{pojistenec.Jmeno} {pojistenec.Prijmeni}, Telefon: {pojistenec.Telefon}, Vek: {pojistenec.Vek}");
            }
        }


    }
}
