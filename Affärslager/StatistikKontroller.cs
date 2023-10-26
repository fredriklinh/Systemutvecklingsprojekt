using Datalager;
using Entiteter.Tjänster;

namespace Affärslager
{
    public class StatistikKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

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

        public List<MasterBokning> HämtaAllaBokningar(int år)
        {
            List<MasterBokning> MS = new List<MasterBokning>();
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                MS.Add(item);
            }

            return MS;
        }

        #region Statistik Logi

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

        public List<string> HämtaUnikaBenämningarLogi()
        {
            return unitOfWork.LogiRepository.GetAll().Select(a => a.Typen).Distinct().ToList();
        }


        public List<Dictionary<int, int>> HämtaAntalBokningarLogi(string Typ, int år)
        {

            List<MasterBokning> ma = new List<MasterBokning>();
            //Hämtar antal bokningar på angivet årtal
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                foreach (Logi item2 in item.ValdLogi)
                {
                    if (item2.Typen == Typ) ma.Add(item);

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
        public List<string> HämtaUnikaTyperUtrustning()
        {
            return unitOfWork.UtrustningRepository.GetAll().Select(a => a.Typ).Distinct().ToList();
        }

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
    }
}
