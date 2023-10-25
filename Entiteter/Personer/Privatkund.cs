using Entiteter.Interface;


namespace Entiteter.Personer
{
    public class Privatkund : Kund, IPerson
    {
        public Privatkund()
        {

        }
        public int PrivatkundId { get; set; }
        public string Personnummer { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        //public virtual IList<Faktura> Fakturor { get; set; } = new List<Faktura>();
        //public virtual IList<MasterBokning> MasterBokningar { get; set; } = new List<MasterBokning>();

    }

}
