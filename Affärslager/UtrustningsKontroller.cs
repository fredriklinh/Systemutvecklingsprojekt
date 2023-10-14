using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using System.Collections.ObjectModel;

namespace Affärslager
{
    public class UtrustningsKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //public IList<Utrustning> HämtaTillgängligUtrustning()
        //{
        //    List<Utrustning> AllaUtrustningar = new List<Utrustning>();

        //    foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
        //    {
        //        AllaUtrustningar.Add(Hej);
        //    }
        //    return AllaUtrustningar;

        //}

        //public IList<Utrustning> HämtaTillgängligUtrustningTyp()
        //{


        //    List<Utrustning> AllaUtrustningar = new List<Utrustning>();

        //    foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
        //    {
        //        AllaUtrustningar.Add(Hej);
        //    }
        //    return AllaUtrustningar;
        //}


        public List<Utrustning> HittaUtrustning(int antal, string typ, string benämning, DateTime slutdatum)
        {

            List<Utrustning> utrustnings = new List<Utrustning>();

            var AllaUtrustningar = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning == benämning).ToList();

            var AllaBokadeUtrustnignar = unitOfWork.UtrustningsBokningRepository.GetAll().Where(a => a.StartDatum > DateTime.Now && a.SlutDatum < slutdatum).ToList();
            List<Utrustning> test123 = new List<Utrustning>();
            foreach (var item in AllaBokadeUtrustnignar)
            {
                foreach (var lista in item.Utrustningar)
                {
                    test123.Add(lista);
                }
            }
            var UnikaUtrustningar = AllaUtrustningar.Concat(test123).Distinct().ToList();

            return UnikaUtrustningar;
        }




        public void SkapaUtrustningsBokningPrivat(List<Utrustning> utrustningar, DateTime slutdatum, Privatkund privatkund, Användare användare, int summa)
        {
            DateTime startdatum = DateTime.Now;
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(a => (a.Privatkund == privatkund) && startdatum >= a.StartDatum && slutdatum <= a.SlutDatum);
            UtrustningsBokning utrustningsBokning = new UtrustningsBokning(masterBokning, startdatum, slutdatum, /*summa,*/ utrustningar);
            masterBokning.UtrustningsBokningar.Add(utrustningsBokning);
            unitOfWork.UtrustningsBokningRepository.Add(utrustningsBokning);
            unitOfWork.Complete();

        }


        public ObservableCollection<int> SökBenämningTyp(string benämning, string typ, DateTime slutdatum)
        {
            List<Utrustning> utrustningAvTyp = new List<Utrustning>();
            DateTime startDatum = DateTime.Now;
            foreach (Utrustning utr in unitOfWork.UtrustningRepository.Find(k => k.Typ.Equals(typ) && k.Benämning.Equals(benämning)))
            {
                utrustningAvTyp.Add(utr);
            }
            foreach (UtrustningsBokning utrustningsBokning in unitOfWork.UtrustningsBokningRepository.Find(f => (startDatum >= f.StartDatum && slutdatum <= f.SlutDatum) || (startDatum <= f.SlutDatum && startDatum >= f.StartDatum) || (slutdatum >= f.StartDatum && slutdatum <= f.SlutDatum) && (startDatum <= f.StartDatum && slutdatum >= f.SlutDatum)))
            {
                foreach (Utrustning utrustning in utrustningsBokning.Utrustningar)
                {
                    utrustningAvTyp.Remove(utrustning);
                }
            }
            return RäknaAntal(utrustningAvTyp);
        }


        private ObservableCollection<int> RäknaAntal(List<Utrustning> utrustnings)
        {
            ObservableCollection<int> antal = new ObservableCollection<int>();
            int steg = 0;
            foreach (Utrustning item in utrustnings)
            {
                if (steg == 50)
                {
                    return antal;
                }
                steg = steg + 1;
                antal.Add(steg);
            }
            return antal;
        }

        public List<Utrustning> SökBenämning(string utrBenämning)
        {
            var querable = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == utrBenämning);

            return querable
                    .GroupBy(i => i.Benämning)
                    .Select(group => group.First())
                    .ToList();
        }

        public IList<Utrustning> SökTyp(Utrustning SelectedItem)
        {
            var querable = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Benämning == SelectedItem.Benämning);

            return querable
                        .GroupBy(i => i.Benämning)
                        .Select(group => group.First())
                        .ToList();
        }
    }
}
