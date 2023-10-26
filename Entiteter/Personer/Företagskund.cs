using Entiteter.Tjänster;

namespace Entiteter.Personer
{
    public class Företagskund : Kund
    {
        public Företagskund()
        {

        }


        //public int FöretagsId { get; set; }

        public string OrgNr { get; set; }
        public string FöretagsNamn { get; set; }

        public double RabattSats { get; set; }

        public virtual IList<Faktura> Fakturor { get; set; } = new List<Faktura>();

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
