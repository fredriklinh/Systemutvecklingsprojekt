using Entiteter.Personer;
using Entiteter.Prislistor;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class MasterBokning
    {
        public MasterBokning()
        {

        }
        [Key]
        public int BokningsNr { get; set; }
        public bool Avbeställningsskydd { get; set; }
        public int NyttjadKreditsumma { get; set; }

        public DateTime BokningsDatum { get; set; } // Attribut för när bokningen skapades i systemet. 
        public DateTime StartDatum { get; set; }
        public DateTime SlutDatum { get; set; }
        public virtual IList<Logi> ValdLogi { get; set; } = new List<Logi>();

        
        public virtual IList<LogiTyp> logiTyper { get; set; } = new List<LogiTyp>();
        public virtual Privatkund Privatkund { get; set; }
        public virtual Företagskund Företagskund { get; set;}
        public virtual Användare Användare { get; set; }

        [ForeignKey("Faktura")]
        public int? Fakturanummer { get; set; }
        public virtual Faktura Faktura { get; set; }







    }
}
