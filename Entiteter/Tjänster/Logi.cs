using Entiteter.Prislistor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class Logi
    {
        [Key]
        public int LogiId { get; set; }
        public int Kvadratmeter { get; set; }
        public int Bäddar { get; set; }
        public bool Kök { get; set; }


        public List <PrislistaLogi> PrislistaLogi { get; set; }
        public List<MasterBokning> MasterBokning { get; set;}
        public List<LogiTyp> LogiTyp { get; set; }




    }
}
