namespace Entiteter.Personer
{
    public class Elev : Person
    {
        public int ID { get; set; }



        public Elev(string förnamn, string efternamn) : base(förnamn, efternamn)
        {
            Förnamn = förnamn;
            Efternamn = efternamn;
        }
    }
}
