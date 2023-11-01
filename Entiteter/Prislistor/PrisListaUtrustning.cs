namespace Entiteter.Prislistor
{
    public class PrisListaUtrustning
    {
        public int PrisId { get; set; }
        public string TypAvUtrustning { get; set; }

        public string BenämningUtrustning { get; set; }

        public int Dag1 { get; set; }
        public int Dag2 { get; set; }
        public int Dag3 { get; set; }
        public int Dag4 { get; set; }
        public int Dag5 { get; set; }


        public PrisListaUtrustning()
        {

        }
    }
}
