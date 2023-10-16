using Entiteter.Tjänster;

namespace PresentationslagerWPF.DataDisplay
{
    public class DisplayUtrustning
    {
        public DisplayUtrustning(int antal, Utrustning propUtrustning, string typ, string benämning, int summa)
        {
            Value = antal;
            PropUtrustning = propUtrustning;
            Typ = typ;
            Benämning = benämning;
            Summa = summa;
        }

        public int Value { get; set; }

        public Utrustning PropUtrustning { get; set; }

        public string Typ { get; set; }

        public string Benämning { get; set; }

        public int Summa { get; set; }

    }
}
