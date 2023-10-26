using Datalager;
using Entiteter.Personer;
using Entiteter.Prislistor;
using Entiteter.Tjänster;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Affärslager
{
    public class PrisKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();



        #region PrisLogi

        //Kontrollerar vecka på ett specifikt datum 
        public static int KontrolleraVecka(DateTime datum)
        {
            CultureInfo myCI = new CultureInfo("sv-SE");
            Calendar myCal = myCI.Calendar;

            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            int datumsVecka = myCal.GetWeekOfYear(datum, myCWR, myFirstDOW);

            return datumsVecka;
        }
        public bool KontrolleraDagarSportlov(List<DateTime> datum)
        {
            bool result = false;
            foreach (var item in datum)
            {
                int VeckaNr = KontrolleraVecka(item);
                if (VeckaNr == 7 || VeckaNr == 8)
                {
                    return result = true;
                }
            }

            return result;
        }



        public double BeräknaPrisLogi(string LogiNamn, DateTime startdatum, DateTime slutdatum)
        {
            //TimeSpan AntalDagarBokade = slutdatum.Subtract(startdatum.AddDays(-1));
            int antalVeckor = (int)Math.Floor((slutdatum - startdatum.AddDays(-1)).TotalDays / 7);
            //Hämta startvecka för att utgå ifrån rätt prissättning
            int VeckaStart = KontrolleraVecka(startdatum);
            int VeckaSlut = KontrolleraVecka(slutdatum);
            double totalpris = 0;

            if (VeckaStart != 7 && VeckaStart != 8 && VeckaSlut != 7 && VeckaSlut != 8)
            {
                var datumBokning = new List<DateTime>();

                //Placerar alla enskillda dagar från bokningen i en lista
                for (var dt = startdatum; dt <= slutdatum; dt = dt.AddDays(1))
                {
                    datumBokning.Add(dt);
                }

                bool startFöre = StartFöreHelVecka(datumBokning);

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
            else 
            {
                totalpris = HämtaPrisSportlov(LogiNamn, startdatum, slutdatum, antalVeckor, totalpris, VeckaStart);
                return totalpris;
            }

        }
        /// <StartFöreHelVecka>
        /// Om vi har en bokning med hela veckor plus extra strödagar räknar denna metod ut om strödagarna är före eller efter den fulla veckan.
        /// </summary>
        /// <param name="datumLista"></param>
        /// <returns></returns>
        public bool StartFöreHelVecka(List<DateTime> datumLista)
        {
            if (datumLista.Count == 0)
            {
                return false;
            }

            DateTime startDatum = datumLista[0];
            DateTime slutDatum = datumLista[datumLista.Count - 1];


            DateTime enVeckaSenare = startDatum.AddDays(7);

            return startDatum.DayOfWeek != DayOfWeek.Monday && startDatum < enVeckaSenare;
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
        public double HämtaPrisSportlov(string LogiNamn, DateTime startdatum, DateTime slutdatum, int antalVeckor, double totalpris, int VeckaStart)
        {
            var datumBokning = new List<DateTime>();

            //Placerar alla enskillda dagar från bokningen i en lista
            for (var dt = startdatum; dt <= slutdatum; dt = dt.AddDays(1))
            {
                datumBokning.Add(dt);
            }

            bool startFöre = StartFöreHelVecka(datumBokning);
            bool restDagarÖver7 = false;
            //Lista med resterande dagar som inte är hela veckor
            List<DateTime> restDatum = HämtaRestDagar(startdatum, slutdatum, startFöre, datumBokning);
            if (restDatum.Count >= 7)
            {
                antalVeckor = antalVeckor - 1;
                restDagarÖver7 = true;
            }
            //Kontrollerar om det finns resterande dagar i bokningen som inte är hela veckor.
            bool dagarISportlov = KontrolleraDagarSportlov(restDatum);
            int totalprisDagarISportLov = 0;
            if (restDatum.Count > 0 /*&& dagarISportlov == false*/)
            {   //Går igenom varje datum i lista restDatum, kontrollerar dess vecka och hämtar det individuella dygnspriset.
                foreach (var dag in restDatum)
                {
                    int vecka = KontrolleraVecka(dag);
                    if (vecka != 7 && vecka != 8)
                    {
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
                    if (vecka == 7 || vecka == 8)
                    {
                        PrislistaLogi prisVeckaFörDagISportLov = unitOfWork.PrisLogiRepository.FirstOrDefault(x => x.Vecka == 7 && x.TypAvLogi == LogiNamn);
                        totalprisDagarISportLov = prisVeckaFörDagISportLov.PrisVecka;
                    }

                }
                totalpris = totalpris + totalprisDagarISportLov;
            }
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
                        //Om det är mer än 2 veckor som bokas med startdatum eller slutdatum inne i vecka 7 eller 8.
                        if (totalprisDagarISportLov == 0 && antalVeckor > 1)
                        {
                            PrislistaLogi prisPerVecka = unitOfWork.PrisLogiRepository.FirstOrDefault(x => x.Vecka == (VeckaStart + 1) && x.TypAvLogi == LogiNamn);
                            totalpris += prisPerVecka.PrisVecka;
                            VeckaStart++;
                        }
                        //Om det är mer än 7 restdagar i bokningen
                        if (restDagarÖver7 == true)
                        {
                            PrislistaLogi prisPerVecka = unitOfWork.PrisLogiRepository.FirstOrDefault(x => x.Vecka == (VeckaStart + 1) && x.TypAvLogi == LogiNamn);
                            totalpris += prisPerVecka.PrisVecka;
                            VeckaStart++;
                        }
                        //Om det endast är 1 hel vecka i bokningen som är vecka 7 eller 8
                        else if (antalVeckor == 1)
                        {
                            PrislistaLogi prisPerVecka = unitOfWork.PrisLogiRepository.FirstOrDefault(x => x.Vecka == (VeckaStart + 1) && x.TypAvLogi == LogiNamn);
                            totalpris += prisPerVecka.PrisVecka;
                            return totalpris;
                        }
                    }
                }
                return totalpris;
            }
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
            return Math.Round(TotalPris, 1);
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
            return Math.Round(TotalPris, 1);
        }


        #endregion


        #region PristUtrustning

        public int BeräknaPrisUtrustning(int antal, string typ, string benämning, DateTime slutid)
        {
            TimeSpan timespan = slutid.Subtract(DateTime.Now);
            int antalDagar = (int)timespan.TotalDays;

            PrisListaUtrustning prislista = unitOfWork.PrisUtrustningRepository.FirstOrDefault(a => (a.TypAvUtrustning == typ) && a.BenämningUtrustning == benämning);

            int Summa = 0;
            for (int d = 1; d <= antal; d++)
            {
                for (int i = 0; i <= antalDagar; i++)
                {
                    if (i == 0) Summa += prislista.Dag1;

                    if (i == 1) Summa += prislista.Dag2;

                    if (i == 2) Summa += prislista.Dag3;

                    if (i == 2) Summa += prislista.Dag4;

                    if (i == 3) Summa += prislista.Dag5;

                    if (i >= 4) Summa += prislista.Dag5 + prislista.Dag5 / 7;
                }
            }
            return Summa;
        }
        #endregion
    }
}
