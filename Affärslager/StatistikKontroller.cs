using Datalager;
using Entiteter.Tjänster;

namespace Affärslager
{
    public class StatistikKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //Populerar ComboBox i presentationslager med år som masterbokningar existerar.
        public List<int> HämtaÅr()
        {
            List<MasterBokning> ma = new List<MasterBokning>();
            //Hämtar antal bokningar på angivet årtal
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.GetAll())
            {
                ma.Add(item);
            }
            var query = ma
                .GroupBy(i => i.StartDatum.Year)
                .Select(group => group.First())
                .Distinct()
                .ToList();
            List<int> årtal = new List<int>();
            foreach (var item in query)
            {
                årtal.Add(item.StartDatum.Year);

            }
            årtal.Sort();
            return årtal;
        }

        //Hämtar alla bokningar för ett angivet år. Returnerar en lsita med dessa bokningar.
        public List<MasterBokning> HämtaAllaBokningar(int år)
        {
            List<MasterBokning> masterboknin = new List<MasterBokning>();
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                masterboknin.Add(item);
            }

            return masterboknin;
        }

        #region Statistik Logi

        //Metod för att beräkna antal bokningar som gjorts ett visst år utifrån månader i året. Returnerar en dicitionay med värde för antal
        //bokningar och vilken månad.
        public List<Dictionary<int, int>> HämtaTotaltAntalBokningarLogi(int år)
        {

            List<MasterBokning> mb = new List<MasterBokning>();
            //Hämtar antal bokningar på angivet årtal
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                mb.Add(item);
            }
            //Grupperar efter månad samt räknas hur många gånger i månaden en bokningen förekommer. Sortera listan på månad.
            var sorteraPerMånad = mb
             .GroupBy(s => s.StartDatum.Month)
             .Select(g => new { Value = g.Key, Count = g.Count() })
             .OrderBy(x => x.Value).ToList();

            //konvertera var grupperaPerMånad till en Dictionary list.
            List<Dictionary<int, int>> grupperadPerMånad = new List<Dictionary<int, int>>();
            foreach (var item in sorteraPerMånad)
            {
                Dictionary<int, int> månadAntal = new Dictionary<int, int>
                {
                    { item.Value, item.Count }
                };
                grupperadPerMånad.Add(månadAntal);
            }

            return grupperadPerMånad;
        }

        //Hämtar unika typer av logi.
        public List<string> HämtaUnikaBenämningarLogi()
        {
            return unitOfWork.LogiRepository.GetAll().Select(a => a.Typen).Distinct().ToList();
        }


        //Hämtar alla logibokningar utifrån angiven typ av logi och år
        public List<Dictionary<int, int>> HämtaAntalBokningarLogi(string Typ, int år)
        {

            List<MasterBokning> ma = new List<MasterBokning>();
            //Hämtar antal bokningar på angivet årtal
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                foreach (Logi logi in item.ValdLogi)
                {
                    if (logi.Typen == Typ) ma.Add(item);

                }

            }
            //Grupperar efter månad samt räknas hur många gånger i månaden en bokningen förekommer. Sortera listan på månad.
            var sorteraPerMånad = ma
             .GroupBy(s => s.StartDatum.Month)
             .Select(g => new { Value = g.Key, Count = g.Count() })
             .OrderBy(x => x.Value).ToList();

            //konvertera var grupperaPerMånad till en Dictionary list.
            List<Dictionary<int, int>> grupperadPerMånad = new List<Dictionary<int, int>>();
            foreach (var item in sorteraPerMånad)
            {
                Dictionary<int, int> månadAntal = new Dictionary<int, int>
                {
                    { item.Value, item.Count }
                };
                grupperadPerMånad.Add(månadAntal);
            }

            return grupperadPerMånad;
        }



        #endregion

        #region Statistik Utrustning

        //Hämtar unikabenämningar för utrustning som inte är paket. Returnerar dessa unika benämningar i en lista.
        public List<string> HämtaUnikaBenämningarUtrustning()
        {
            string paket = "Paket";
            List<string> result = unitOfWork.UtrustningRepository.GetAll().Select(a => a.Benämning).Distinct().ToList();
            List<string> updatedResult = new List<string>();

            foreach (var item in result)
            {
                if (item != paket)
                {
                    updatedResult.Add(item);
                }
            }

            return updatedResult;
        }

        //Hämtar antal bokningar för utrustningsboknignar utifrån typ och år.
        public List<Dictionary<int, int>> HämtaAntalBokningarUtrustning(string Typ, int år)
        {

            List<UtrustningsBokning> ub = new List<UtrustningsBokning>();
            //Hämtar antal bokningar på angivet årtal
            foreach (UtrustningsBokning item in unitOfWork.UtrustningsBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                foreach (Utrustning item2 in item.Utrustningar)
                {
                    if (item2.Benämning == Typ) ub.Add(item);

                }

            }
            //Grupperar efter månad samt räknas hur många gånger i månaden en bokningen förekommer. Sortera listan på månad.
            var sorteraPerMånad = ub
             .GroupBy(s => s.StartDatum.Month)
             .Select(g => new { Value = g.Key, Count = g.Count() })
             .OrderBy(x => x.Value).ToList();

            //konvertera var grupperaPerMånad till en Dictionary list.
            List<Dictionary<int, int>> grupperadPerMånad = new List<Dictionary<int, int>>();
            foreach (var item in sorteraPerMånad)
            {
                Dictionary<int, int> månadAntal = new Dictionary<int, int>
                {
                    { item.Value, item.Count }
                };
                grupperadPerMånad.Add(månadAntal);
            }

            return grupperadPerMånad;
        }

        #endregion

        #region EJ AKTIVA METODER
        //EJ AKTIV
        public List<string> HämtaUnikaTyperUtrustning()
        {
            return unitOfWork.UtrustningRepository.GetAll().Select(a => a.Typ).Distinct().ToList();
        }

        //EJ AKTIV Hämtar totalt antal bokningar för utrustning utifrån ett specifikt år.
        public List<Dictionary<int, int>> HämtaTotaltAntalBokningarUtrustning(int år)
        {

            List<UtrustningsBokning> ub = new List<UtrustningsBokning>();
            //Hämtar antal bokningar på angivet årtal
            foreach (UtrustningsBokning item in unitOfWork.UtrustningsBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                ub.Add(item);
            }
            //Grupperar efter månad samt räknas hur många gånger i månaden en bokningen förekommer. Sortera listan på månad.
            var sorteraPerMånad = ub
             .GroupBy(s => s.StartDatum.Month)
             .Select(g => new { Value = g.Key, Count = g.Count() })
             .OrderBy(x => x.Value).ToList();

            //konvertera var grupperaPerMånad till en Dictionary list.
            List<Dictionary<int, int>> grupperadPerMånad = new List<Dictionary<int, int>>();
            foreach (var item in sorteraPerMånad)
            {
                Dictionary<int, int> månadAntal = new Dictionary<int, int>
                {
                    { item.Value, item.Count }
                };
                grupperadPerMånad.Add(månadAntal);
            }

            return grupperadPerMånad;
        }
        #endregion 
    }
}
