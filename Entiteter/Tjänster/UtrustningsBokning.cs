using Entiteter.Personer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class UtrustningsBokning
    {
        public int UtrustningBokningsId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public int Summa { get; set; }

        // Beskriver om kunden tog bokning på kredit
        public bool PåKredit { get; set; }

        public virtual MasterBokning MasterBokning { get; set; }

        public virtual IList<Utrustning> Utrustningar { get; set; } = new List<Utrustning>();

        public virtual Användare Användare { get; set; }



        [ForeignKey("Faktura")]

        public int? FakturaID { get; set; }

        public virtual Faktura? Faktura { get; set; }



        public UtrustningsBokning(MasterBokning masterbokning, DateTime startDatum, DateTime slutDatum, int summa, bool påKredit, IList<Utrustning> utrustningar, Användare användare)
        {
            MasterBokning = masterbokning;
            StartDatum = startDatum;
            SlutDatum = slutDatum;
            Summa = summa;
            PåKredit = påKredit;
            Utrustningar = utrustningar;
            Användare = användare;
        }
        public UtrustningsBokning()
        {

        }
    }
}
