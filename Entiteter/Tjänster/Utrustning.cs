using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class Utrustning
    {
        public int UtrustningsId { get; set; }
        public bool Tillgänglig { get; set; }
        //public string Typ { get; set; } 
        public string Benämning { get; set; }   

        
        public Utrustning()
        {
            
        }

    }
}
