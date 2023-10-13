using Entiteter.Tjänster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationslagerWPF.DataDisplay
{
    public class DisplayUtrustning
    {

        public DisplayUtrustning(int antal, Utrustning propUtrustning, string typ, string benämning)
        {
            Value = antal;
            PropUtrustning = propUtrustning;
            Typ = typ;
            Benämning = benämning;
        }

        public int Value { get; set; }

        public Utrustning PropUtrustning { get; set; }

        public string Typ { get; set; }

        public string Benämning { get; set; }

    }
}
