namespace Entiteter.Personer
{
    public class Användare : Person
    {
        public Användare()
        {

        }

        public Användare(int behörighetsnivå, string användarnamn, string lösenord, string förnamn, string efternamn) : base()
        {
            Behörighetsnivå = behörighetsnivå;
            Användarnamn = användarnamn;
            Lösenord = lösenord;
            Förnamn = förnamn;
            Efternamn = efternamn;
        }

        public int Behörighetsnivå { get; set; }

        public string Användarnamn { get; set; }

        public string Lösenord { get; set; }




    }
}
