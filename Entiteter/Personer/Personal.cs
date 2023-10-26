using Entiteter.Tjänster;

namespace Entiteter.Personer
{
    public class Personal : Person
    {
        public int AnstNr { get; set; }
        public string Befattning { get; set; }
        //[ForeignKey("Lektion")]
        //public string LektionsTillfälle { get; set; }
        //public virtual Lektion? Lektion { get; set; }


        public Personal() { }

    }
}
