namespace Entiteter.Personer
{
    public class Användare : Person
    {
        public Användare()
        {

        }
        public int AnvändarID { get; set; }
        public int Behörighetsnivå { get; set; }

        public string Användarnamn { get; set; }

        public string Lösenord { get; set; }


        //public List<MasterBokning> MasterBoknings { get; set; }


    }
}
