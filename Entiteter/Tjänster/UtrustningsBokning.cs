using Entiteter.Personer;

namespace Entiteter.Tjänster
{
    public class UtrustningsBokning
    {
        public int UtrustningBokningsId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public int Summa { get; set; }


        public virtual MasterBokning MasterBokning { get; set; }

        public virtual IList<Utrustning> Utrustningar { get; set; } = new List<Utrustning>();

        public virtual Användare Användare { get; set; }

        public UtrustningsBokning(MasterBokning masterbokning, DateTime startDatum, DateTime slutDatum, int summa, IList<Utrustning> utrustningar, Användare användare)
        {
            MasterBokning = masterbokning;
            StartDatum = startDatum;
            SlutDatum = slutDatum;
            Summa = summa;
            Utrustningar = utrustningar;
            Användare = användare;
        }
        public UtrustningsBokning()
        {

        }
    }
}
