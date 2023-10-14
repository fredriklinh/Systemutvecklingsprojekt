using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using System;
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

        public UtrustningsBokning SkapaUtrustningsBokningPrivat(List<int> antal, List<Utrustning> utrustningar, DateTime slutdatum, Privatkund privatkund, Användare användare/*, int summa*/)
        {
            List<Utrustning> resulterandeUtrustningar = new List<Utrustning>();
            foreach (Utrustning item in utrustningar)
            {
                foreach (int i in antal)
                {
                    for (int x = 0; x < i; x++)
                    {
                        foreach (Utrustning utrustning in unitOfWork.UtrustningRepository.Find(a => a.Benämning == item.Benämning && a.Typ == item.Typ))
                        {
                            resulterandeUtrustningar.Add(utrustning);
                        }
                    }
                }
            }

            

            //for (int i = 0; i < antal.Count && i < utrustningar.Count; i++)
            //{
            //    for (int j = 0; j < antal[i]; j++)
            //    {
            //        resulterandeUtrustningar.Add(utrustningar[i]);
            //    }
            //}
            DateTime startdatum = DateTime.Now;
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(a => (a.Privatkund == privatkund) && startdatum >= a.StartDatum && slutdatum <= a.SlutDatum);
            UtrustningsBokning utrustningsBokning = new UtrustningsBokning(masterBokning, startdatum, slutdatum, /*summa,*/ resulterandeUtrustningar);
            masterBokning.UtrustningsBokningar.Add(utrustningsBokning);
            unitOfWork.UtrustningsBokningRepository.Add(utrustningsBokning);
            unitOfWork.Complete();
            return utrustningsBokning;
        }

        //public UtrustningsBokning SkapaUtrustningsBokningFöretag(List<Utrustning> utrustningar, DateTime slutdatum)
        //{


        //}

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
