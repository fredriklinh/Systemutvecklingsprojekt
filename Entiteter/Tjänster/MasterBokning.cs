using Entiteter.Personer;
using Entiteter.Prislistor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class MasterBokning
    {
        [Key]
        public int BokningsNr { get; set; }
        public bool Avbeställningsskydd { get; set; }
        public int NyttjadKreditsumma { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public List<Logi> ValdLogi { get; set; }

        public List<LogiTyp> logiTyper { get; set; }
        public Privatkund Privatkund { get; set; }
        public Företagskund Företagskund { get; set;}
        public Användare Användare { get; set; }
        

        //public Faktura Faktura { get; set; }//

        



    

    }
}
