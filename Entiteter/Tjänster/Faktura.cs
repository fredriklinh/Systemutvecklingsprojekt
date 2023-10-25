namespace Entiteter.Tjänster
{
    public class Faktura
    {
        public Faktura()
        {

        }


        public int FakturaId { get; set; }
        public DateTime UtskriftsDatum { get; set; }
        public int Moms { get; set; }
        public bool Delbetalning { get; set; }
        public int TotalBelopp { get; set; }

        //[ForeignKey("MasterBokning")]
        //public int? Bokningsnummer { get; set; }
        //public virtual MasterBokning MasterBokning { get; set; }


    }
}
