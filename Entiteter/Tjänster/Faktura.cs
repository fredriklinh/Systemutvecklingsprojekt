using Entiteter.Personer;

namespace Entiteter.Tjänster
{
    public class Faktura
    {
        public Faktura()
        {

        }



        public int FakturaId { get; set; }

        public string FakturaName { get; set; }

        public DateTime UtskriftsDatum { get; set; }

        public int Moms { get; set; }

        public int TotalBelopp { get; set; }
        public string Kund { get; set; }


        public Faktura(string fakturaName, DateTime utskriftsDatum, int moms, int totalBelopp, Företagskund företagskund)
        {
            FakturaName = fakturaName;
            UtskriftsDatum = utskriftsDatum;
            Moms = moms;
            TotalBelopp = totalBelopp;
            Kund = företagskund.OrgNr;
        }
        public Faktura(string fakturaName, DateTime utskriftsDatum, int moms, int totalBelopp, Privatkund privatkund)
        {
            FakturaName = fakturaName;
            UtskriftsDatum = utskriftsDatum;
            Moms = moms;
            TotalBelopp = totalBelopp;
            Kund = privatkund.Personnummer;
        }

    }
}
