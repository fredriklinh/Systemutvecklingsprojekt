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

        public Faktura(string fakturaName, DateTime utskriftsDatum, int moms, int totalBelopp)
        {
            FakturaName = fakturaName;
            UtskriftsDatum = utskriftsDatum;
            Moms = moms;
            TotalBelopp = totalBelopp;
        }


        //[ForeignKey("MasterBokning")]
        //public int? Bokningsnummer { get; set; }
        //public virtual MasterBokning MasterBokning { get; set; }


    }
}
