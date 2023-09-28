using Entiteter.Interface;
using Entiteter.Tjänster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
