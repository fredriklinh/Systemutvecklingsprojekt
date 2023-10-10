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

        public static int CheckWeek(DateTime datum)
        {
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;

            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            int datumsVecka = myCal.GetWeekOfYear(datum, myCWR, myFirstDOW);

            return datumsVecka;
        }

        public double BeräknaPrisLogi(string LogiNamn, DateTime startdatum, DateTime slutdatum)
        {
            var datum = new List<DateTime>();
            int VeckaStart = CheckWeek(startdatum);
            for (var dt = startdatum; dt <= slutdatum; dt = dt.AddDays(1))
            {
                datum.Add(dt);
            }
            List<int> intRest = new List<int>();
            foreach (var item in datum)
            {
                intRest.Add(CheckWeek(item));
            }
            //for (var i = intRest.Count - 1; i >= 0; i--)
            //{
            //    if (intRest.Contains(VeckaStart))
            //    {
            //        datum.RemoveAt(i);
            //    }
            //}

            //Ta fram variablar som krävs för uträkning
            TimeSpan AntalDagarBokade = slutdatum.Subtract(startdatum.AddDays(-1));
            int antalVeckor = (int)Math.Floor((slutdatum - startdatum.AddDays(-1)).TotalDays / 7);
            
            double restDagar = AntalDagarBokade.TotalDays - (antalVeckor * 7);
            
            //Kollar Vecka på stardatum
            
            
            double totalpris = 0;
            for (int i = antalVeckor; i <= VeckaStart + antalVeckor; i++)
            {
                //Tillfällig prisLogi

                PrislistaLogi prisLogiVecka = unitOfWork.PrisLogiRepository.FirstOrDefault(a => a.TypAvLogi == LogiNamn && a.Vecka == VeckaStart);
                
                if (antalVeckor == 0)
                {
                    DateTime date;
                    // USE REMAINDER 
                    for (DateTime ii = startdatum; ii < slutdatum; ii = ii.AddDays(1))
                    {
                        // Kolla om dagen är Lördag eller Söndag. Annar Läggs vardagspris till.
                        if (ii.DayOfWeek == DayOfWeek.Saturday || ii.DayOfWeek == DayOfWeek.Friday)
                        {
                            totalpris += prisLogiVecka.PrisHelg;
                        }
                        else
                        {
                            totalpris += prisLogiVecka.PrisVardag;
                        }
                    }
                }
                else
                {
                    totalpris += prisLogiVecka.PrisVecka;
                    return totalpris;
                }
                return totalpris;
            }
            return totalpris;
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
