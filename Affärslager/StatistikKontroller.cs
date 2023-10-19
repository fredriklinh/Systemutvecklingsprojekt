﻿using Datalager;
using Entiteter.Tjänster;

namespace Affärslager
{
    public class StatistikKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        #region StatistikLogi

        public List<MasterBokning> HämtaAllaBokningar(int år)
        {
            List<MasterBokning> MS = new List<MasterBokning>();
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                MS.Add(item);
            }

            return MS;
        }

        public List<Dictionary<int, int>> HämtaAntalBokningar(int år)
        {

            List<MasterBokning> ma = new List<MasterBokning>();
            //Hämtar antal bokningar på angivet årtal
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                ma.Add(item);
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

        #endregion
    }
}
