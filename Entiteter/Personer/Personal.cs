using Entiteter.Tjänster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Personer
{
    public class Personal: Person 
    {
        public int AnstNr { get; set; }
        public string Befattning { get; set; }

        public virtual IList<GruppLektion> Lektion { get; set; }
        //[ForeignKey("Lektion")]
        //public string LektionsTillfälle { get; set; }
        //public virtual Lektion? Lektion { get; set; }


        public Personal() { }

    }
}
