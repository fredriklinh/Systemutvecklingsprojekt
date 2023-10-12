using Entiteter.Enums;
using Entiteter.Personer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class GruppLektion
    {
        public string ID { get; set; } 
        public string LektionsTillfälle {  get; set; }
        //public int[] AntalDeltagare = new int[14];

        public virtual IList<Elev> Deltagare { get; set; } = new List<Elev>();
        public double Pris {  get; set; }

        public Svårighetsgrad Svårighetsgrad { get; set; }
        

        [ForeignKey("Personal")]
        public int? Lärare { get; set; }
        public virtual Personal Personal { get; set; } = null!;
        
        public GruppLektion() { }   
    }
}
