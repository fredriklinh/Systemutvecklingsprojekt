namespace Entiteter.Tjänster
{
    public class Konferenslokal
    {
        public string KonferensBenämningsId { get; set; }
        public string Storlek { get; set; }

        public int AntalPlatser { get; set; }

        public virtual IList<MasterBokning> MasterBokning { get; set; } = new List<MasterBokning>();



    }
}
