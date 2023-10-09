using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Prislistor
{
    public class PrisListaUtrustning
    {
        public int PrisId { get; set; }
        public string TypAvUtrustning { get; set; }
        public int Vecka { get; set; }

        public int PrisVardag { get; set; }
        public int PrisHelg { get; set; }
        public int PrisVecka { get; set; }


        public PrisListaUtrustning()
        {
               
        }
    }
}
