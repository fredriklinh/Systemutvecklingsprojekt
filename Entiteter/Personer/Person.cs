namespace Entiteter.Personer
{
    public abstract class Person
    {

        public string Förnamn { get; set; }
        public string Efternamn { get; set; }

        public Person(string förnamn, string efternamn)
        {
            förnamn = Förnamn;
            efternamn = Efternamn;
        }
    }
}
