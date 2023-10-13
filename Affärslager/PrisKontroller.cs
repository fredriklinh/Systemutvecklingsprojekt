using Datalager;
using Entiteter.Personer;
using Entiteter.Prislistor;
using Entiteter.Tjänster;
using System.Globalization;

namespace Affärslager
{
    public class PrisKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public static int KontrolleraVecka(DateTime datum)
        {
            CultureInfo myCI = new CultureInfo("sv-SE");
            Calendar myCal = myCI.Calendar;

            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            int datumsVecka = myCal.GetWeekOfYear(datum, myCWR, myFirstDOW);

            return datumsVecka;
        }

        public double BeräknaPrisLogi(string LogiNamn, DateTime startdatum, DateTime slutdatum)
        {
            //TimeSpan AntalDagarBokade = slutdatum.Subtract(startdatum.AddDays(-1));
            int antalVeckor = (int)Math.Floor((slutdatum - startdatum.AddDays(-1)).TotalDays / 7);
            //Hämta startvecka för att utgå ifrån rätt prissättning
            int VeckaStart = KontrolleraVecka(startdatum);
            double totalpris = 0;

            var sportVeckorKontroll = new List<DateTime>();
            //Placerar alla enskillda dagar från bokningen i en lista
            for (var dt = startdatum; dt <= slutdatum; dt = dt.AddDays(1))
            {
                sportVeckorKontroll.Add(dt);
            }

            var datumBokning = new List<DateTime>();

            //Placerar alla enskillda dagar från bokningen i en lista
            for (var dt = startdatum; dt <= slutdatum; dt = dt.AddDays(1))
            {
                datumBokning.Add(dt);
            }

            bool startFöre = StartsBeforeWholeWeek(datumBokning);

            //Lista med resterande dagar som inte är hela veckor
            List<DateTime> restDatum = HämtaRestDagar(startdatum, slutdatum, startFöre, datumBokning);
            //Kontrollerar om det finns resterande dagar i bokningen som inte är hela veckor.
            if (restDatum.Count > 0)
            {   //Går igenom varje datum i lista restDatum, kontrollerar dess vecka och hämtar det individuella dygnspriset.
                foreach (var dag in restDatum)
                {
                    int vecka = KontrolleraVecka(dag);
                    PrislistaLogi prisLogiDag = unitOfWork.PrisLogiRepository.FirstOrDefault(a => a.TypAvLogi == LogiNamn && a.Vecka == vecka);
                    // Kolla om dagen är Lördag eller Söndag. Annar Läggs vardagspris till.
                    if (dag.DayOfWeek == DayOfWeek.Saturday || dag.DayOfWeek == DayOfWeek.Friday)
                    {
                        totalpris += prisLogiDag.PrisHelg;
                    }
                    else
                    {
                        totalpris += prisLogiDag.PrisVardag;
                    }
                }
            }
            //Om det finns hela veckor, räknar ut priset för varje individuell vecka och lägger till i totalpris.

            if (startFöre == false)
            {
                if (antalVeckor > 0)
                {
                    for (int v = 0; v < antalVeckor; v++)
                    {
                        PrislistaLogi prisPerVecka = unitOfWork.PrisLogiRepository.FirstOrDefault(x => x.Vecka == VeckaStart && x.TypAvLogi == LogiNamn);
                        totalpris += prisPerVecka.PrisVecka;
                        VeckaStart++;
                    }
                }
                return totalpris;
            }
            else
            {
                if (antalVeckor > 0)
                {
                    for (int v = 0; v < antalVeckor; v++)
                    {
                        PrislistaLogi prisPerVecka = unitOfWork.PrisLogiRepository.FirstOrDefault(x => x.Vecka == (VeckaStart + 1) && x.TypAvLogi == LogiNamn);
                        totalpris += prisPerVecka.PrisVecka;
                        VeckaStart++;
                    }
                }
                return totalpris;
            }


        }

        public bool StartsBeforeWholeWeek(List<DateTime> dateList)
        {
            if (dateList.Count == 0)
            {
                return false; // Empty list, can't determine if it starts before a whole week.
            }

            DateTime startDate = dateList[0];
            DateTime endDate = dateList[dateList.Count - 1];

            // Calculate the date one week from the start date.
            DateTime oneWeekLater = startDate.AddDays(7);

            return startDate.DayOfWeek != DayOfWeek.Monday && startDate < oneWeekLater;
        }


        public List<DateTime> HämtaRestDagar(DateTime startdatum, DateTime slutdatum, bool startFöre, List<DateTime> restDatum)
        {
            if (startFöre == true)
            {
                //Nya sättet med radering av dagar bakifrån
                int consecutiveCount = 1;
                List<int> intRest = new List<int>();
                for (int i = 0; i < restDatum.Count; i++)
                {
                    int result = KontrolleraVecka(restDatum[i]);
                    intRest.Add(result);

                    // Kontrollera om det aktuella elementet är samma som det föregående elementet
                    if (i > 0 && result == intRest[i - 1])
                    {
                        consecutiveCount++;
                    }
                    else
                    {
                        consecutiveCount = 1;
                    }

                    // Om samma nummer uppträder sju gånger i följd, ta bort dem
                    if (consecutiveCount == 7)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            intRest.RemoveAt(i - j); // Ta bort från intRest
                            restDatum.RemoveAt(i - j);    // Ta bort från datum
                        }
                        i -= 7; // Flytta tillbaka index med 6 eftersom du har tagit bort 7 element
                    }
                }
            }
            else
            {
                //Om bokning är mer än 7 dagar, raderar vi 7 dagars intervaller för att få fram bokningens resterande dagar som inte är hela veckor.
                for (int i = 0; i <= restDatum.Count; i++)
                {
                    if (i == 7)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            restDatum.RemoveAt((i - 1) - j);
                        }
                        i -= 7; //flytta tillbaka index 7 steg så att det första datumets vecka i lista restDatum kontrolleras.
                    }
                }
            }
            return restDatum;
        }

        //Denna metod ska fixas innan inlämning!!!!
        public int HämtaPrisSportlov(string LogiNamn, DateTime startdatum, DateTime slutdatum, List<DateTime> sportVeckorKontroll)
        {
            int totalprisSportlov = 0;

            foreach (var dag in sportVeckorKontroll)
            {
                int vecka = KontrolleraVecka(dag);
                if (vecka == 7 || vecka == 8)
                {
                    PrislistaLogi sportLov = unitOfWork.PrisLogiRepository.FirstOrDefault(a => a.TypAvLogi == LogiNamn && a.Vecka == 7);
                    totalprisSportlov = sportLov.PrisVecka;
                }
                if (true)
                {

                }
            }
            return totalprisSportlov;
        }

        public double HämtaRabatt(double TotalPris, Privatkund privatkund)
        {
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(m => m.PersonNr == privatkund.Personnummer && m.BokningsDatum >= DateTime.Now.AddYears(-1));

            if (masterBokning != null)
            {
                double rabatt = 0.92;
                TotalPris = TotalPris * rabatt;
            }
            else
            {
                TotalPris = default;
            }
            return TotalPris;
        }

        public double HämtaRabattFöretagskund(double TotalPris, Företagskund företagskund)
        {
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(m => m.OrgaNr == företagskund.OrgNr);

            if (masterBokning != null)
            {
                double rabatt = företagskund.RabattSats;
                TotalPris = TotalPris * rabatt;
            }
            else
            {
                TotalPris = default;
            }
            return TotalPris;
        }
    }
}
