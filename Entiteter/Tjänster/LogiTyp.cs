﻿using Entiteter.Prislistor;
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

        public string LogiTypId { get; set; }

        public virtual IList<Logi> Logier { get; set; }


        public LogiTyp()
        {

        }

        
        
        
    }
}
