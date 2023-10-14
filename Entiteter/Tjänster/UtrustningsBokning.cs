namespace Entiteter.Tjänster
{
    public class UtrustningsBokning
    {
        public string UtrustningBokningsId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        //public int Summa { get; set; }  
        public MasterBokning MasterBokning { get; set; }
        public virtual IList<Utrustning> Utrustningar { get; set; } = new List<Utrustning>();

        public UtrustningsBokning(MasterBokning masterbokning, DateTime startDatum, DateTime slutDatum, /*int summa,*/ IList<Utrustning> utrustningar)
        {
            StartDatum = startDatum;
            SlutDatum = slutDatum;
            //Summa = summa;
            Utrustningar = utrustningar;
        }
    }
}
