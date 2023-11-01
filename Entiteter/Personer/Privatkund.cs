using Entiteter.Interface;
using Entiteter.Tjänster;


namespace Entiteter.Personer
{
    public class Privatkund : Kund, IPerson
    {



        public string Personnummer { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public virtual IList<Faktura> Fakturor { get; set; } = new List<Faktura>();
        public virtual IList<MasterBokning> MasterBokningar { get; set; } = new List<MasterBokning>();




        public Privatkund()
        {

        }

        public Privatkund(string personnummer, string postnummer, string ort, string telefonnummer, string mailAdress, string adress, string förnamn, string efternamn)
        {
            //Från kund
            MaxBeloppsKreditGräns = 12000;
            Adress = adress;
            Postnummer = postnummer;
            Ort = ort;
            Telefonnummer = telefonnummer;
            MailAdress = mailAdress;
            //Från privatkund
            Personnummer = personnummer;
            Förnamn = förnamn;
            Efternamn = efternamn;


        }
    }

}
