namespace Entiteter.Personer
{
    public class Företagskund : Kund
    {
        public Företagskund()
        {

        }


        public int FöretagsId { get; set; }
        public string OrgNr { get; set; }
        public string FöretagsNamn { get; set; }

        public double RabattSats { get; set; }




    }
}
