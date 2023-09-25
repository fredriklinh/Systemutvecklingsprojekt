using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Tjänster
{
    public class Faktura
    {
        [Key]
        public int FakturaId { get; set; }
        public DateTime UtskriftsDatum { get; set; }
        public int Moms { get; set; }
        public bool Delbetalning { get; set; }
        public int TotalBelopp { get; set; }

        public MasterBokning MasterBokning { get; set; }


    }
}
