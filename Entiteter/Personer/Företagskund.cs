using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Personer
{
    public class Företagskund: Kund
    {
        public Företagskund()
        {

        }

        [Key]
        public int FöretagsId { get; set; }
        public string OrgNr { get; set; }
        public string FöretagsNamn { get; set; }

        public double RabattSats { get; set; }

        


    }
}
