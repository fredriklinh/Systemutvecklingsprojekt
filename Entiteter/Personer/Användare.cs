using Entiteter.Tjänster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entiteter.Personer
{
    public class Användare : Person
    {
        [Key]
        public int AnvändarID { get; set; }
        public int BehörighetsNivå { get; set; }

        public string Användarnamn { get; set; }

        public string Lösenord { get; set; }


        public List<MasterBokning> MasterBoknings { get; set; }


    }
}
