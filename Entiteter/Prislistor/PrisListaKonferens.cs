namespace Entiteter.Prislistor
{
    public class PrisListaKonferens
    {
        
        public int PrisId { get; set; }
        public int Vecka { get; set; }
        public string Storlek { get; set; }
        public int DygnsPris { get; set; }
        public int TimPris { get; set; }
        public int VeckoPris { get; set; }
        
        public PrisListaKonferens()
        {

        }
    }
}
