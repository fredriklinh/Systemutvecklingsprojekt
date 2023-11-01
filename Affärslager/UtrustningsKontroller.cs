using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;
using System.Collections.ObjectModel;

namespace Affärslager
{
    public class UtrustningsKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();


        //Metod för att beräkna och hitta tillgänliga paket
        public IList<Utrustning> HittaPaket(int antal, string typ, string benämning, DateTime slutdatum, List<Utrustning> tempUtrustningar)
        {
            DateTime dagensDatum = DateTime.Now.Date;

            IList<Utrustning> UnikaBenämningarUtrustning = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning != benämning).Distinct().ToList(); // Mån , Tis, Ons , Tor , Fre, Lör, Sön

            //Grupperar unika benämningar 
            var BenämningarUnika = UnikaBenämningarUtrustning.GroupBy(x => x.Benämning).Select(group => group.First()).Distinct().ToList();

            //Hämtar alla paket som finns tillgängliga
            IList<Utrustning> AllaUtrustningar = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning != benämning && a.Status == true).ToList(); // Mån , Tis, Ons , Tor , Fre, Lör, Sön
            IList<UtrustningsBokning> AllaBokadeUtrustnignar = unitOfWork.UtrustningsBokningRepository.GetAll().Where(f => (dagensDatum <= f.StartDatum && slutdatum <= f.SlutDatum) || (dagensDatum <= f.StartDatum && slutdatum >= f.SlutDatum) || (dagensDatum >= f.SlutDatum && dagensDatum <= f.StartDatum) || (slutdatum <= f.StartDatum && slutdatum >= f.SlutDatum) && (dagensDatum >= f.StartDatum && slutdatum <= f.SlutDatum)).ToList();


            IList<Utrustning> tempUtrustning = new List<Utrustning>();
            foreach (var item in AllaBokadeUtrustnignar)
            {
                foreach (var lista in item.Utrustningar.Where(a => a.Status == false))
                {
                    tempUtrustning.Add(lista);
                }
            }

            //Tar bort duplikat
            foreach (Utrustning item in AllaUtrustningar.ToList())
            {
                if (tempUtrustning.Contains(item))
                {
                    AllaUtrustningar.Remove(item);
                }
            }

            IList<Utrustning> MatchadeUtrustningar = new List<Utrustning>();
            int index = 0;
            foreach (var itemPaket in BenämningarUnika)
            {
                foreach (Utrustning item in AllaUtrustningar)
                {
                    if (index >= antal) break;
                    if (item.Typ == typ && item.Benämning == itemPaket.Benämning)
                    {
                        if (!tempUtrustningar.Contains(item))
                        {
                            if (!MatchadeUtrustningar.Contains(item))
                            {
                                index++;

                                MatchadeUtrustningar.Add(item);
                            }
                        }

                    }
                }
                index = 0;
            }
            return MatchadeUtrustningar;
        }


        //Hittar utrustnign som är tillgnäglig för bokning utifrån angivet slutdaum och DateTime.Now. 
        public IList<Utrustning> HittaUtrustning(int antal, string typ, string benämning, DateTime slutdatum, List<Utrustning> tempUtrustningar)
        {
            DateTime dagensDatum = DateTime.Now.Date;

            IList<Utrustning> AllaUtrustningar = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == typ && a.Benämning == benämning && a.Status == true).ToList(); // Mån , Tis, Ons , Tor , Fre, Lör, Sön

            //Tittar på tillgänliga utrustningar inom start och slutdatum
            IList<UtrustningsBokning> AllaBokadeUtrustnignar = unitOfWork.UtrustningsBokningRepository.GetAll().Where(f => (dagensDatum <= f.StartDatum && slutdatum <= f.SlutDatum) || (dagensDatum <= f.StartDatum && slutdatum >= f.SlutDatum) || (dagensDatum >= f.SlutDatum && dagensDatum <= f.StartDatum) || (slutdatum <= f.StartDatum && slutdatum >= f.SlutDatum) && (dagensDatum >= f.StartDatum && slutdatum <= f.SlutDatum)).ToList();

            IList<Utrustning> tempUtrustning = new List<Utrustning>();
            foreach (var item in AllaBokadeUtrustnignar)
            {
                foreach (var lista in item.Utrustningar.Where(a => a.Status == false))
                {
                    tempUtrustning.Add(lista);
                }
            }

            //Tar bort duplikat som finns i tempUtrustning och AllaUtrustningar
            foreach (Utrustning item in AllaUtrustningar.ToList())
            {
                if (tempUtrustning.Contains(item))
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
                    if (!tempUtrustningar.Contains(item))
                    {
                        if (!MatchadeUtrustningar.Contains(item))
                        {
                            index++;

                            MatchadeUtrustningar.Add(item);
                        }
                    }

                }
            }
            return MatchadeUtrustningar;
        }

        //Hämtar utrustningsbokning för företagskund. Returnerar en lista med utrustningar som bokning innehåller.
        public IList<Utrustning> HämtaUtrustningsbokningFöretagskund(Företagskund företagskund)
        {
            DateTime datumIBokning = DateTime.Now;
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.SlutDatum >= datumIBokning && a.UtrustningsBokningar != null && a.OrgaNr == företagskund.OrgNr);
            UtrustningsBokning utrustningsBokning = unitOfWork.UtrustningsBokningRepository.FirstOrDefault(b => b.SlutDatum >= datumIBokning && b.MasterBokning.OrgaNr == företagskund.OrgNr);
            IList<Utrustning> utrustningar = new List<Utrustning>();
            foreach (var item in masterBokning.UtrustningsBokningar)
            {
                foreach (Utrustning utr in item.Utrustningar)
                {
                    utrustningar.Add(utr);
                }
            }
            return utrustningar;
        }

        //Hämtar utrustningsbokning för privatkund. Returnerar en lista med utrustningar som bokning innehåller.
        public IList<Utrustning> HämtaUtrustningsbokningPrivatkund(Privatkund privatkund)
        {
            DateTime datumIBokning = DateTime.Now;
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.SlutDatum >= datumIBokning && a.UtrustningsBokningar != null && a.PersonNr == privatkund.Personnummer);
            UtrustningsBokning utrustningsBokning = unitOfWork.UtrustningsBokningRepository.FirstOrDefault(b => b.SlutDatum >= datumIBokning && b.MasterBokning.PersonNr == privatkund.Personnummer);
            if (utrustningsBokning == null)
            {
                return null;
            }
            IList<Utrustning> utrustningar = new List<Utrustning>();
            foreach (var item in masterBokning.UtrustningsBokningar)
            {
                foreach (Utrustning utr in item.Utrustningar)
                {
                    utrustningar.Add(utr);
                }
            }
            return utrustningar;
        }

        //Kollar om utrustningsboknign existerar eller inte utifrån angivet bokningsnummer
        public UtrustningsBokning UtrustningsBokningExisterar(string bokningsNr)
        {
            return unitOfWork.UtrustningsBokningRepository.FirstOrDefault(a => a.UtrustningBokningsId.ToString() == bokningsNr);
        }


        //Skapar utrustningsbokning för företagskund. Tilldelar även masterbokningen värde av bokningens kredit om kund har valt att lägga betalning på kredit.
        public MasterBokning SkapaUtrustningsBokningFöretag(List<Utrustning> utrustningar, DateTime slutdatum, Företagskund företagskund, Användare användare, int summa, bool påKredit)
        {
            DateTime startdatum = DateTime.Now;
            MasterBokning masterBokningFöretag = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.OrgaNr == företagskund.OrgNr && startdatum >= a.StartDatum && slutdatum <= a.SlutDatum);
            if (masterBokningFöretag == null) return masterBokningFöretag;
            //Kollakredit
            if (påKredit == true) masterBokningFöretag.NyttjadKreditsumma = masterBokningFöretag.NyttjadKreditsumma + summa;
            if (masterBokningFöretag.NyttjadKreditsumma > företagskund.MaxBeloppsKreditGräns)
            {
                return masterBokningFöretag;
            }
            Användare korrektAnvändare = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.Användarnamn.Equals(användare.Användarnamn));
            UtrustningsBokning utrustningsBokning = new UtrustningsBokning(masterBokningFöretag, startdatum, slutdatum, summa, påKredit, utrustningar, korrektAnvändare);
            masterBokningFöretag.UtrustningsBokningar.Add(utrustningsBokning);
            unitOfWork.UtrustningsBokningRepository.Add(utrustningsBokning);
            unitOfWork.Complete();
            return masterBokningFöretag;
        }

        //Skapar utrustningsbokning för privatkund. Tilldelar även masterbokningen värde av bokningens kredit om kund har valt att lägga betalning på kredit.
        public MasterBokning SkapaUtrustningsBokningPrivat(List<Utrustning> utrustningar, DateTime slutdatum, Privatkund privatkund, Användare användare, int summa, bool påKredit)
        {
            DateTime startdatum = DateTime.Now;
            MasterBokning masterBokningPrivat = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.Privatkund.Personnummer == privatkund.Personnummer && startdatum >= a.StartDatum && slutdatum <= a.SlutDatum);
            if (masterBokningPrivat == null) return masterBokningPrivat;
            //Kollakredit
            if (påKredit == true) masterBokningPrivat.NyttjadKreditsumma = masterBokningPrivat.NyttjadKreditsumma + summa;
            if (masterBokningPrivat.NyttjadKreditsumma > privatkund.MaxBeloppsKreditGräns && påKredit == true) return masterBokningPrivat;

            Användare korrektAnvändare = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.Användarnamn.Equals(användare.Användarnamn));
            UtrustningsBokning utrustningsBokning = new UtrustningsBokning(masterBokningPrivat, startdatum, slutdatum, summa, påKredit, utrustningar, korrektAnvändare);
            masterBokningPrivat.UtrustningsBokningar.Add(utrustningsBokning);
            unitOfWork.UtrustningsBokningRepository.Add(utrustningsBokning);
            unitOfWork.Complete();
            return masterBokningPrivat;
        }


        //Söker utrustning utifrån angiven benämning, typ och om de är tillgängliga för ett visst datum. Räknar slutligen hur många som är tillgänliga
        //och returnerar antal tillgängliga.
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

        //Metod för att söka paket som finnss tillgänliga utifrån benämning, typ och datum som de är tillgänliga. Beräknar slutligen antalet tillgängliga paket.
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

        //Räknar på antalet paket tillgänligUtrustning innehåller med det minsta värde som basis för hur många paket som kan bokas
        //Returnerar max 50 st.
        private ObservableCollection<int> RäknaAntalPaket(List<Utrustning> tillgänligUtrustning)
        {
            //Grupperar listan efter hur många gånger en string förekommer med den minsta värdet överst
            var SorteraAntal = tillgänligUtrustning
             .GroupBy(s => s.Benämning)
             .Select(g => new { Value = g.Key, Count = g.Count() })
             .OrderBy(x => x.Count);

            //Hämtar det första värde i SorteraAntal => Minsta värdet
            var minstFörekommande = SorteraAntal.FirstOrDefault();

            ObservableCollection<int> AntalPaket = new ObservableCollection<int>();
            for (int i = 0; i < minstFörekommande.Count; i++)
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

        //Fullbordar återlämmning efter att återlämnad utrustning stämmer överens med uthyrt utrustning
        public MasterBokning FullbordaÅterlämning(string InputÅterlämning)
        {
            int input = Int32.Parse(InputÅterlämning);
            UtrustningsBokning utrustningsbokning = unitOfWork.UtrustningsBokningRepository.FirstOrDefault(a => a.UtrustningBokningsId == input);


            foreach (Utrustning item in utrustningsbokning.Utrustningar) item.StatusTillgänglig();

            if (utrustningsbokning.PåKredit == true)
            {
                UtrustningsBokning utrustningsbokningFaktura = SkapaFaktura(utrustningsbokning);
                unitOfWork.Complete();
                unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.UtrustningsBokningar == utrustningsbokning);

                foreach (MasterBokning item in unitOfWork.MasterBokningRepository.GetAll())
                {
                    foreach (UtrustningsBokning utrustningsBokning in item.UtrustningsBokningar)
                    {
                        if (utrustningsBokning.UtrustningBokningsId == input) return item;

                    }
                }
            }
            unitOfWork.Complete();
            return null;
        }

        //Skapar faktura för uthyrning av utrustning.
        public UtrustningsBokning SkapaFaktura(UtrustningsBokning utrustningsbokning)
        {
            if (utrustningsbokning.MasterBokning.Privatkund == null)
            {
                utrustningsbokning.Faktura = new Faktura("Utrustning", DateTime.Now, 25, utrustningsbokning.Summa, utrustningsbokning.MasterBokning.Företagskund);
            }
            else
            {
                utrustningsbokning.Faktura = new Faktura("Utrustning", DateTime.Now, 25, utrustningsbokning.Summa, utrustningsbokning.MasterBokning.Privatkund);
            }
            return utrustningsbokning;
        }

        //Populerar och söker paket för skidshop
        public List<Utrustning> SökPaket(string paket)
        {

            var allaPaket = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Benämning == paket);

            return allaPaket
                .GroupBy(i => i.Typ)
                .Select(group => group.First())
                .ToList();

        }

        //Populerar och söker utrustnign för skidshop.
        public List<Utrustning> SökBenämning(string utrBenämning)
        {
            var querable = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == utrBenämning);

            return querable
                    .GroupBy(i => i.Benämning)
                    .Select(group => group.First())
                    .ToList();
        }

        #region EJ AKTIV

        //EJ AKTVI Tillkommit
        private MasterBokning KollaKredtiTotal(int summaBokning, MasterBokning masterBokning)
        {
            //SKA TESTAS
            masterBokning.NyttjadKreditsumma = masterBokning.NyttjadKreditsumma + summaBokning;

            return masterBokning;

        }



        // EJ AKTIV ÄLDRE - AXEL
        public MasterBokning BokningExisterar(string bokningsNr)
        {
            return unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.BokningsNr.ToString() == bokningsNr);
        }

        //EJ AKTIV Hämtar tillgängliga utrustningar utifrån typer
        public IList<Utrustning> HämtaTillgängligUtrustningTyp()
        {
            List<Utrustning> AllaUtrustningar = new List<Utrustning>();

            foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
            {
                AllaUtrustningar.Add(Hej);
            }
            return AllaUtrustningar;
        }

        //EJ AKTIV Hämtar tillgänglig utrustning för utrustningsbokning
        public IList<Utrustning> HämtaTillgängligUtrustning()
        {
            List<Utrustning> AllaUtrustningar = new List<Utrustning>();

            foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
            {
                AllaUtrustningar.Add(Hej);
            }
            return AllaUtrustningar;

        }
        #endregion
    }
}
