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
        [Key]
        public int PrivatkundId { get; set; }
        public string Personnummer { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public List<Faktura> Fakturor { get; set; }
        public List<MasterBokning> MasterBokningar { get; set; }
        
    }
    
}
