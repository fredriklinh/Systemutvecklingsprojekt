using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using System.Collections;
using System.Collections.ObjectModel;

namespace Affärslager
{
    public class UtrustningsKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public IList<Utrustning> HämtaTillgängligUtrustning()
        {
            List<Utrustning> AllaUtrustningar = new List<Utrustning>();

            foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
            {
                AllaUtrustningar.Add(Hej);
            }
            return AllaUtrustningar;

        }

        public IList<Utrustning> HämtaTillgängligUtrustningTyp()
        {


            List<Utrustning> AllaUtrustningar = new List<Utrustning>();

            foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
            {
                AllaUtrustningar.Add(Hej);
            }
            return AllaUtrustningar;
        }
        public IList<Utrustning> HittaPaket(int antal, string typ, string benämning, DateTime slutdatum)
        {
            DateTime dagensDatum = DateTime.Now.Date;

            IList<Utrustning> UnikaBenämningarUtrustning = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning != benämning).Distinct().ToList(); // Mån , Tis, Ons , Tor , Fre, Lör, Sön
                       
            var BenämningarUnika = UnikaBenämningarUtrustning.GroupBy(x => x.Benämning).Select(group => group.First()).Distinct().ToList();

            IList<Utrustning> AllaUtrustningar = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning != benämning && a.Status == true).ToList(); // Mån , Tis, Ons , Tor , Fre, Lör, Sön
            IList<UtrustningsBokning> AllaBokadeUtrustnignar = unitOfWork.UtrustningsBokningRepository.GetAll().Where(f => (dagensDatum <= f.StartDatum && slutdatum <= f.SlutDatum) || (dagensDatum <= f.StartDatum && slutdatum >= f.SlutDatum) || (dagensDatum >= f.SlutDatum && dagensDatum <= f.StartDatum) || (slutdatum <= f.StartDatum && slutdatum >= f.SlutDatum) && (dagensDatum >= f.StartDatum && slutdatum <= f.SlutDatum)).ToList();

            IList<UtrustningsBokning> test222 = unitOfWork.UtrustningsBokningRepository.GetAll().ToList();

            IList<Utrustning> test123 = new List<Utrustning>();
            foreach (var item in AllaBokadeUtrustnignar)
            {
                foreach (var lista in item.Utrustningar)
                {
                    test123.Add(lista);
                }
            }

            foreach (Utrustning item in AllaUtrustningar.ToList())
            {
                if (test123.Contains(item))
                {
                    AllaUtrustningar.Remove(item);
                }
            }
            IList<Utrustning> MatchadeUtrustningar = new List<Utrustning>();
            int index = 1;
            foreach (var itemPaket in BenämningarUnika)
            {
                foreach (Utrustning item in AllaUtrustningar)
                {
                    if (index >= antal) break;
                    if (item.Typ == typ && item.Benämning == itemPaket.Benämning)
                    {
                        if (!MatchadeUtrustningar.Contains(item))
                        {
                            index++;
                            MatchadeUtrustningar.Add(item);
                        }
                    }
                }
                index = 0;
            }
            return MatchadeUtrustningar;
        }


        public IList<Utrustning> HittaUtrustning(int antal, string typ, string benämning, DateTime slutdatum)
        {
            DateTime dagensDatum = DateTime.Now.Date;
                                                                                                                                             //Tis--------------Fre            TIDIGARE BOKNING
            IList<Utrustning> AllaUtrustningar = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning == benämning && a.Status == true).ToList(); // Mån , Tis, Ons , Tor , Fre, Lör, Sön

            IList<UtrustningsBokning> AllaBokadeUtrustnignar = unitOfWork.UtrustningsBokningRepository.GetAll().Where(f => (dagensDatum <= f.StartDatum && slutdatum <= f.SlutDatum) || (dagensDatum <= f.StartDatum && slutdatum >= f.SlutDatum) || (dagensDatum >= f.SlutDatum && dagensDatum <= f.StartDatum) || (slutdatum <= f.StartDatum && slutdatum >= f.SlutDatum) && (dagensDatum >= f.StartDatum && slutdatum <= f.SlutDatum)).ToList();
            IList<UtrustningsBokning> test222 = unitOfWork.UtrustningsBokningRepository.GetAll().ToList();



            IList<Utrustning> test123 = new List<Utrustning>();
            foreach (var item in AllaBokadeUtrustnignar)
            {
                foreach (var lista in item.Utrustningar)
                {
                    test123.Add(lista);
                }
            }
            //var UnikaUtrustningar = AllaUtrustningar.Concat(test123).Distinct().ToList();
            foreach (Utrustning item in AllaUtrustningar.ToList())
            {
                if (test123.Contains(item))
                {
                    AllaUtrustningar.Remove(item);
                }
            }
            IList<Utrustning> MatchadeUtrustningar = new List<Utrustning>();
            int index = 1;
            foreach (Utrustning item in AllaUtrustningar)
            {
                if (index > antal)
                {
                    break;
                }
                if (item.Typ == typ && item.Benämning == benämning)
                {
                    if (!MatchadeUtrustningar.Contains(item))
                    {
                        index++;

                        MatchadeUtrustningar.Add(item);

                    }
                }
            }
            return MatchadeUtrustningar;
        }

        public MasterBokning BokningExisterar(string bokningsNr)
        {
            return unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.BokningsNr.ToString() == bokningsNr);
        }

        //OBS Tillkommit
        private void KollaKredtiTotal(double kreditTotalKund, int summaBokning, MasterBokning masterBokning)
        {
            if(masterBokning.NyttjadKreditsumma + summaBokning <= kreditTotalKund) masterBokning.NyttjadKreditsumma += summaBokning;
            unitOfWork.Complete();
        }


        //Tillkommit
        public MasterBokning SkapaUtrustningsBokningFöretag(List<Utrustning> utrustningar, DateTime slutdatum, Företagskund företagskund, Användare användare, int summa, bool påKredit)
        {
            DateTime startdatum = DateTime.Now;
            MasterBokning masterBokningFöretag = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.OrgaNr == företagskund.OrgNr && startdatum >= a.StartDatum && slutdatum <= a.SlutDatum);
            if (masterBokningFöretag == null) return masterBokningFöretag;
            //Kollakredit
            if (påKredit == true) KollaKredtiTotal(företagskund.MaxBeloppsKreditGräns, summa, masterBokningFöretag);

            Användare korrektAnvändare = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.AnvändarID.Equals(användare.AnvändarID));
            UtrustningsBokning utrustningsBokning = new UtrustningsBokning(masterBokningFöretag, startdatum, slutdatum, summa, utrustningar, korrektAnvändare);
            masterBokningFöretag.UtrustningsBokningar.Add(utrustningsBokning);
            unitOfWork.UtrustningsBokningRepository.Add(utrustningsBokning);
            unitOfWork.Complete();
            return masterBokningFöretag;
        }
        public MasterBokning SkapaUtrustningsBokningPrivat(List<Utrustning> utrustningar, DateTime slutdatum, Privatkund privatkund, Användare användare, int summa, bool påKredit)
        {
            DateTime startdatum = DateTime.Now;
            MasterBokning masterBokningPrivat = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.Privatkund.Personnummer == privatkund.Personnummer && startdatum >= a.StartDatum && slutdatum <= a.SlutDatum);
            if (masterBokningPrivat == null) return masterBokningPrivat;
            //Kollakredit
            if (påKredit == true) KollaKredtiTotal(privatkund.MaxBeloppsKreditGräns, summa, masterBokningPrivat);
            
            Användare korrektAnvändare = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.AnvändarID.Equals(användare.AnvändarID));
            UtrustningsBokning utrustningsBokning = new UtrustningsBokning(masterBokningPrivat, startdatum, slutdatum, summa, utrustningar, korrektAnvändare);
            masterBokningPrivat.UtrustningsBokningar.Add(utrustningsBokning);
            unitOfWork.UtrustningsBokningRepository.Add(utrustningsBokning);
            unitOfWork.Complete();
            return masterBokningPrivat;
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
        public ObservableCollection<int> SökPaketTyp(string benämning, string typ, DateTime slutdatum)
        {
            DateTime startDatum = DateTime.Now;

            List<Utrustning> TillgängligUtrustning = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning != benämning).ToList();

            foreach (UtrustningsBokning utrustningsBokning in unitOfWork.UtrustningsBokningRepository.Find(f => (startDatum >= f.StartDatum && slutdatum <= f.SlutDatum) || (startDatum <= f.SlutDatum && startDatum >= f.StartDatum) || (slutdatum >= f.StartDatum && slutdatum <= f.SlutDatum) && (startDatum <= f.StartDatum && slutdatum >= f.SlutDatum)))
            {
                foreach (Utrustning utrustning in utrustningsBokning.Utrustningar)
                {
                    TillgängligUtrustning.Remove(utrustning);
                }
            }
            return RäknaAntalPaket(TillgängligUtrustning);
        }

        private ObservableCollection<int> RäknaAntalPaket(List<Utrustning> tillgänligUtrustning)
        {
            //Grupperar listan efter hur många gånger en string förekommer med den minsta värdet överst
            var SorteraAntal = tillgänligUtrustning
             .GroupBy(s => s.Benämning)
             .Select(g => new { Value = g.Key, Count = g.Count() })
             .OrderBy(x => x.Count);

            //Hämtar det första värde i SorteraAntal => Minsta värdet
            var minsFörekommande = SorteraAntal.FirstOrDefault();

            ObservableCollection<int> AntalPaket = new ObservableCollection<int>();
            for (int i = 0; i < minsFörekommande.Count; i++)
            {
                if (AntalPaket.Count > 50) break;
                AntalPaket.Add(i);

            }
            return AntalPaket;
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

        public void FullbordaÅterlämning(string InputÅterlämning)
        {
            int input = Int32.Parse(InputÅterlämning);
            MasterBokning masterbokning = unitOfWork.MasterBokningRepository.FirstOrDefault(e => e.BokningsNr == input);
            IList<UtrustningsBokning> utrustningsBokningar = unitOfWork.UtrustningsBokningRepository.GetAll().Where(a => a.MasterBokning.BokningsNr == masterbokning.BokningsNr).ToList();
            foreach (var item in utrustningsBokningar)
            {
                foreach (Utrustning utr in item.Utrustningar)
                {
                    utr.StatusTillgänglig();
                }
            }
            //foreach (var item in masterbokning.UtrustningsBokningar)
            //{
            //    foreach (Utrustning utr in item.Utrustningar)
            //    {
            //        utr.StatusTillgänglig();
            //    }
            //}
            unitOfWork.Complete();
        }

        public List<Utrustning> SökPaket(string paket)
        {

            var allaPaket = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Benämning == paket);

            return allaPaket
                .GroupBy(i => i.Typ)
                .Select(group => group.First())
                .ToList();

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
