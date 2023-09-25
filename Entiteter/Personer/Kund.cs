using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteter.Personer
{
    public abstract class Kund
    {
        
        public double MaxBeloppsKreditGräns { get; set; }
        public double RabattSats { get; set; }
        public string Adress { get; set; }
        public int PostNummer { get; set; }
        public string Ort { get; set; }
        public string Telefonnummer { get; set; }
        public string MailAdress { get; set; }
                
        
    }
}
