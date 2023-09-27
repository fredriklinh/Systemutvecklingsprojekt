using Datalager;
using Entiteter.Prislistor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int BeräknaPrisLogi(string typAvLogi, DateTime startdatum, DateTime slutdatum)
        {

            // Kolla resterande dagar, Kolla veckor
            if (startdatum > slutdatum)
            {
                Console.WriteLine("Ange korrekt nummer");
            }

            //Ta fram variablar som krävs för uträkning
            TimeSpan AntalDagarBokade = slutdatum.Subtract(startdatum);
            int antalVeckor = (int)Math.Floor((slutdatum - startdatum).TotalDays / 7);
            double restDagar = AntalDagarBokade.TotalDays - (antalVeckor * 7);
            Console.WriteLine("Total vara bokningen i: {0} dagar,", AntalDagarBokade.TotalDays);
            Console.WriteLine("Antal Veckor: {0} ", antalVeckor);
            Console.WriteLine("Övriga dagar: {0} ", restDagar);

            //Kollar Vecka på stardatum
            int VeckaStart = CheckWeek(startdatum);
            Console.WriteLine("Vecka för stardatum: {0}", VeckaStart);
            int totalpris = 0;
            for (int i = antalVeckor; i <= VeckaStart + antalVeckor; i++)
            {
                //Tillfällig prisLogi
                
                PrislistaLogi prisLogiVecka = unitOfWork.PrisLogiRepository.FirstOrDefault(a => a.TypAvLogi == typAvLogi && a.Vecka == VeckaStart);
                int antalVeckorKvar = antalVeckor - i;
                if (antalVeckorKvar == 0)
                {
                    DateTime date;
                    // USE REMAINDER 
                    for (DateTime ii = startdatum; ii <= slutdatum; ii = ii.AddDays(1))
                    {
                        // Kolla om dagen är Lördag eller Söndag. Annar Läggs vardagspris till.
                        if (ii.DayOfWeek == DayOfWeek.Saturday || ii.DayOfWeek == DayOfWeek.Sunday)
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
    }
}
