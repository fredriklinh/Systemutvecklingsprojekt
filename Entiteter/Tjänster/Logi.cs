using Entiteter.Prislistor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class Logi
    {
        public Logi()
        {

        }

        public string LogiId { get; set; }
        public string LogiNamn { get; set; }
        public int Kvadratmeter { get; set; }
        public int Bäddar { get; set; }
        public bool Kök { get; set; }

        

        public bool ÄrTillgänglig { get; set; }
        
        public virtual IList<PrislistaLogi> PrislistaLogi { get; set; } = new List<PrislistaLogi>();
        public virtual IList<MasterBokning> MasterBokning { get; set; } = new List<MasterBokning>();

        //public LogiTyp Typ { get; set; }



        //Ska vara enum istället, tre olika metoder, för att definiera "pågående", tillgänglig och bokad"
        public void Tillgänlig()
        {
            ÄrTillgänglig = true;
        }
        public void Bokad()
        {
            ÄrTillgänglig = false;
        }

    

    }
}
