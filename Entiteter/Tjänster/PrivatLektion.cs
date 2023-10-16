using Entiteter.Personer;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class PrivatLektion
    {
        public string ID { get; set; }
        public string LektionsTillfälle { get; set; }
        public virtual IList<Elev> Deltagare { get; set; } = new List<Elev>();
        public double Pris { get; set; }


        [ForeignKey("Personal")]
        public int? Lärare { get; set; }
        public virtual Personal? Personal { get; set; }
        public PrivatLektion()
        {

        }
    }
}
