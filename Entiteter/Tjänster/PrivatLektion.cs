using Entiteter.Enums;
using Entiteter.Personer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class PrivatLektion
    {
        public int ID { get; set; }
        public string LektionsTillfälle { get; set; }
        //public int[] AntalDeltagare = new int[1];
        public virtual IList<Elev> Deltagare {  get; set; } = new List<Elev>();

        public double Pris = 375;


        [ForeignKey("Personal")]
        public string Förnamn { get; set; }
        public virtual Personal? Personal { get; set; }
        public PrivatLektion() { }
    }
}
