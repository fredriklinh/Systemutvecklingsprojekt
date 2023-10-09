using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entiteter.Tjänster;

namespace Entiteter.Tjänster
{
    public class UtrustningsTyp
    {
        public int ID { get; set; }
        public string Typ {  get; set; } 
        public virtual IList<Utrustning> Utrustning { get; set; }

        public UtrustningsTyp()
        {
           
        }
    }
}
