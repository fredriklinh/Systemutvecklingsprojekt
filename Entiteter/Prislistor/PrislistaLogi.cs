using Entiteter.Tjänster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Prislistor
{
    public class PrislistaLogi

    {

        public PrislistaLogi()
        {

        }
        
        
        [Key]public int PrisId { get; set; }
        public string TypAvLogi { get; set; }
        public int Vecka { get; set; }

        public int PrisVardag { get; set; }
        public int PrisHelg { get; set; }
        public int PrisVecka { get; set; }

        //public virtual Logi Logi { get; set; }
    }
}
