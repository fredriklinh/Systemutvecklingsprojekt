using Entiteter.Personer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class MasterBokning
    {
        public MasterBokning()
        {

        }



        public int BokningsNr { get; set; }
        public bool Avbeställningsskydd { get; set; }
        public int NyttjadKreditsumma { get; set; }

        public DateTime BokningsDatum { get; set; } // Attribut för när bokningen skapades i systemet. 
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public virtual IList<Logi> ValdLogi { get; set; } = new List<Logi>();
        public virtual IList<Konferenslokal> ValdaKonferenser { get; set; } = new List<Konferenslokal>();
        public virtual IList<UtrustningsBokning> UtrustningsBokningar { get; set; } = new List<UtrustningsBokning>();

        [ForeignKey("Företagskund")]
        public string? OrgaNr { get; set; }
        public virtual Företagskund? Företagskund { get; set; } = null!;

        [ForeignKey("Privatkund")]
        public string? PersonNr { get; set; }
        public virtual Privatkund? Privatkund { get; set; } = null!;


        [ForeignKey("Användare")]
        public string? SkapadAv { get; set; }
        public virtual Användare? Användare { get; set; }


        //Construktor Privatkund
        public MasterBokning(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Privatkund privatkund, Användare användare)
        {

            Avbeställningsskydd = avbeställningsskydd;
            NyttjadKreditsumma = 0;
            BokningsDatum = DateTime.Now;
            StartDatum = startDatum;
            SlutDatum = slutDatum;
            ValdLogi = valdLogi;
            Privatkund = privatkund;
            Användare = användare;
        }

        //Construktor Företagskund

        public MasterBokning(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Företagskund företagskund, Användare användare)
        {
            Avbeställningsskydd = avbeställningsskydd;
            NyttjadKreditsumma = 0;
            BokningsDatum = DateTime.Now;
            StartDatum = startDatum;
            SlutDatum = slutDatum;
            ValdLogi = valdLogi;
            Företagskund = företagskund;
            Användare = användare;
            Användare = användare;
        }





        //[ForeignKey("Faktura")]
        //public int? Fakturanummer { get; set; }
        //public virtual Faktura Faktura { get; set; }







    }
}
