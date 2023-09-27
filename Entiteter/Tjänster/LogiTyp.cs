using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class LogiTyp
    {
        public LogiTyp()
        {

        }

        [Key]
        public int LogiTypID { get; set; }
        public virtual MasterBokning MasterBokning { get; set; }
        public virtual Logi Logi { get; set; }
        public double TypPris { get; set; }

    }
}
