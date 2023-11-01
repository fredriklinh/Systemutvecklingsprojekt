using Entiteter.Tjänster;

namespace PresentationslagerWPF.DataDisplay
{
    public class DisplayUtrustning
    {

        //Används för att visa formaterad information i utrustningsfönster

        public DisplayUtrustning(int antal, Utrustning propUtrustning, string typ, string benämning, int summa)
        {
            Value = antal;
            PropUtrustning = propUtrustning;
            Typ = typ;
            Benämning = benämning;
            Summa = summa;
        }
        public DisplayUtrustning(int antal, Utrustning propUtrustning, string typ, string benämning, bool status)
        {
            Value = antal;
            PropUtrustning = propUtrustning;
            Typ = typ;
            Benämning = benämning;
            Status = status;
        }

        public int Value { get; set; }

        public Utrustning PropUtrustning { get; set; }

        public string Typ { get; set; }

        public string Benämning { get; set; }

        public int Summa { get; set; }
        public bool Status { get; set; }

    }
}
