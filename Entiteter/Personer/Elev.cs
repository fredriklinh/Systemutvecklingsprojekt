﻿using Entiteter.Tjänster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Personer
{
    public class Elev : Person
    {
        public int ID { get; set; }

        public GruppLektion? GruppLektion { get; set; }
        public PrivatLektion? PrivatLektion { get; set; }
        public Elev(string förnamn, string efternamn): base(förnamn, efternamn)
        {
            Förnamn = förnamn;
            Efternamn = efternamn;
        }
    }
}
