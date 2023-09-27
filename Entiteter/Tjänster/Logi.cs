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

        [Key]
        public int LogiId { get; set; }
        public int Kvadratmeter { get; set; }
        public int Bäddar { get; set; }
        public bool Kök { get; set; }

        public virtual IList<MasterBokning> MasterBokning { get; set; } = new List<MasterBokning>();
        public virtual IList<LogiTyp> LogiTyp { get; set; } = new List<LogiTyp>();




    }
}
