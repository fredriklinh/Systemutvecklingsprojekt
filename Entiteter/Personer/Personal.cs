using Entiteter.Tjänster;

namespace Entiteter.Personer
{
    public class Personal : Person
    {
        public int AnstNr { get; set; }
        public string Befattning { get; set; }

        public virtual IList<GruppLektion> Lektion { get; set; }




        public Personal() { }

    }
}
