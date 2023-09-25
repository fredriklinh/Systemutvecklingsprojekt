using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class LogiTyp
    {
        [Key]
        public int LogiTypID { get; set; }
        public MasterBokning MasterBokning { get; set; }
        public Logi Logi { get; set; }
        public double TypPris { get; set; }

    }
}
