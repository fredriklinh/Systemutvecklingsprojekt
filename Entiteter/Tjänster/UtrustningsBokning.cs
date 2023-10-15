namespace Entiteter.Tjänster
{
    public class UtrustningsBokning
    {
        public int UtrustningBokningsId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        //public int Summa { get; set; }  

        public virtual MasterBokning MasterBokning { get; set; }

        public virtual IList<Utrustning> Utrustningar { get; set; } = new List<Utrustning>();

        public UtrustningsBokning(MasterBokning masterbokning, DateTime startDatum, DateTime slutDatum, IList<Utrustning> utrustningar)
        {
            MasterBokning = masterbokning;
            StartDatum = startDatum;
            SlutDatum = slutDatum;
            //Summa = summa;
            Utrustningar = utrustningar;
        }
        public UtrustningsBokning()
        {

        }
    }
}
