using Affärslager;




internal class Program
{


    public static void Main(string[] args)
    {

        BokningsKontroller kontroller = new BokningsKontroller();
        kontroller.LaddaData();

    }
}