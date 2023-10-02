using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entiteter.Tjänster;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entiteter.Personer
{
    public class Företagskund: Kund
    {
        public Företagskund()
        {

        }


        //public int FöretagsId { get; set; }

        public string OrgNr { get; set; }
        public string FöretagsNamn { get; set; }

        public double RabattSats { get; set; }

        public virtual IList<Faktura> Fakturor { get; set; } = new List<Faktura>();
        public virtual IList<MasterBokning> MasterBokningar { get; set; } = new List<MasterBokning>();

        public Företagskund(double maxBeloppsKreditGränds, string adress, string postnummer, string ort, string telefonnummer, string mailAdress, string orgNr, string företagsNamn, double rabattSats)
        {
            //Från Kund
            MaxBeloppsKreditGräns = maxBeloppsKreditGränds;
            Adress = adress;
            Postnummer = postnummer;
            Ort = ort;
            Telefonnummer = telefonnummer;
            MailAdress = mailAdress;
            //Från Företagskund
            OrgNr = orgNr;
            FöretagsNamn = företagsNamn;
            RabattSats = rabattSats;
        }
    }
}
