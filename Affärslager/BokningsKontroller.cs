using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;

namespace Affärslager
{
    public class BokningsKontroller
    {
        public BokningsKontroller()
        {

        }

        public UnitOfWork UnitOfWork
        {
            get => default;
            set
            {
            }
        }

        public UnitOfWork unitOfWork = new UnitOfWork();



        /// <summary>
        /// Metoden kollar igenom alla logier mellan två angivna datum som har status tillgänglig true samt kollar igenom alla bokade logier som är utanför angivet datum f
        /// </summary>
        /// <param name="startdatum"></param>
        /// <param name="slutdatum"></param>
        /// <returns></returns>
        /// 
        public List<Logi> HämtaTillgängligLogi(DateTime startdatum, DateTime slutdatum)
        {

            List<Logi> logi = new List<Logi>();


            foreach (Logi allLogi in unitOfWork.LogiRepository.GetAll())
            {
                logi.Add(allLogi);
            }
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(f =>
            (startdatum >= f.StartDatum && slutdatum <= f.SlutDatum) ||
            (startdatum <= f.SlutDatum && startdatum >= f.StartDatum) ||
            (slutdatum >= f.StartDatum && slutdatum <= f.SlutDatum) ||
            (startdatum <= f.StartDatum && slutdatum >= f.SlutDatum)))
            {
                foreach (Logi ledigLogi in item.ValdLogi)
                {
                    logi.Remove(ledigLogi);
                }

            }
            return logi;
        }

        //Metoden tar parameterar och söker upp privatkund, användare och för att sedan användas som parameter och skapa en MasterBokning. Returnerar en Masterbokning
        public MasterBokning SkapaMasterbokningPrivatkund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Privatkund privatkund, Användare användare)
        {
            Privatkund privatkund1 = unitOfWork.PrivatkundRepository.FirstOrDefault(pk => pk.Personnummer.Equals(privatkund.Personnummer));
            Användare användare1 = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.Användarnamn.Equals(användare.Användarnamn));
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, privatkund1, användare1, null);
            unitOfWork.MasterBokningRepository.Add(masterBokning);
            unitOfWork.Complete();
            return masterBokning;
        }

        //Metoden tar parameterar och söker upp företagskund, användare och för att sedan användas som parameter och skapa en MasterBokning. Returnerar en Masterbokning
        public MasterBokning SkapaMasterbokningFöretagskund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Företagskund företagskund, Användare användare)
        {
            Företagskund företagskund1 = unitOfWork.FöretagskundRepository.FirstOrDefault(fk => fk.OrgNr.Equals(företagskund.OrgNr));
            Användare användare1 = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.Användarnamn.Equals(användare.Användarnamn));
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, företagskund1, användare1);
            unitOfWork.MasterBokningRepository.Add(masterBokning);
            unitOfWork.Complete();
            return masterBokning;
        }


        //EJ AKTIV METOD
        public void KonferensTillMasterBokning(IList<Konferenslokal> kLista, MasterBokning mb)
        {

            foreach (Konferenslokal kl in kLista)
            {
                mb.ValdaKonferenser.Add(kl);
            }
            unitOfWork.MasterBokningRepository.Update(mb);
            unitOfWork.Complete();
        }


        //Söker först igenom bokningar på privatkunder om inget hittas söker vi på företagskunder, om ingen hittas på företagskund går vi sist på bokningsnummer och returnerar.
        public List<MasterBokning> HämtaKundsMasterbokningar(string kundnummer)
        {
            List<MasterBokning> masterbokningar = new List<MasterBokning>();

            foreach (MasterBokning itemP in unitOfWork.MasterBokningRepository.Find(pmb => pmb != null && pmb.PersonNr != null && pmb.PersonNr.Equals(kundnummer)))
            {
                masterbokningar.Add(itemP);
            }
            if (masterbokningar.Count > 0)
            {
                return masterbokningar;
            }
            foreach (MasterBokning itemF in unitOfWork.MasterBokningRepository.Find(fmb => fmb != null && fmb.OrgaNr != null && fmb.OrgaNr.Equals(kundnummer)))
            {
                masterbokningar.Add(itemF);
                return masterbokningar;
            }
            //OBS Personummer måste vara en int
            if (long.TryParse(kundnummer, out long parsedValue))
            {
                foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(e => e.BokningsNr == parsedValue))
                {
                    masterbokningar.Add(item);
                }
            }
            return masterbokningar;
        }

        public void RättSiffra(string kundnummer) // typ av int accepterar endast positiva tal
        {
            uint siffra; // variabelnamn för tal som är mer än 0
            while (!uint.TryParse(kundnummer, out siffra)) // sålänge som påståendet inte stämmer: 
            {

            }
        }

        //Hämtar den privatkund som är aktiv i skidshop. Tar in privatkund och datum som parametrar.
        public MasterBokning HämtaAktivPrivatkundMasterbokning(Privatkund privatkund, DateTime datum)
        {
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.SlutDatum.Date >= datum && a.StartDatum.Date <= datum && a.PersonNr == privatkund.Personnummer);
            return masterBokning;
        }

        //Hämtar den företagskund som är aktiv i skidshop. Tar in privatkund och datum som parametrar.
        public MasterBokning HämtaAktivFöretagskundMasterbokning(Företagskund företagskund, DateTime datum)
        {
            MasterBokning masterBokning = unitOfWork.MasterBokningRepository.FirstOrDefault(a => a.SlutDatum >= datum && a.StartDatum <= datum && a.OrgaNr == företagskund.OrgNr);
            return masterBokning;
        }


        //Hämtar en masterboknign för angiven företagskund. Tar in OrgNr som parameter
        public List<MasterBokning> HämtaMasterbokningarFöretag(string OrgNr)
        {
            List<MasterBokning> företagMasterbokning = new List<MasterBokning>();

            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(kl => kl.OrgaNr.Equals(OrgNr)))
            {
                företagMasterbokning.Add(item);
            }
            return företagMasterbokning;
        }

        //Sparar ändringar till masterbokning
        public void SparaÄndring(MasterBokning masterBokning)
        {
            unitOfWork.MasterBokningRepository.Update(masterBokning);
            unitOfWork.Complete();
        }

        //Tar bort masterbokning
        public void TaBortMasterBokning(MasterBokning masterBokning)
        {
            unitOfWork.MasterBokningRepository.Delete(masterBokning);
            unitOfWork.Complete();
        }


        //Metoden ska plocka bort vald Logi från masterbekoningen och spara detta 
        public void TaBortLogiFrånBokning(MasterBokning masterBokning, Logi logi)
        {
            //// Behöver lösa logiken att ta bort vald logi
            //logi.MasterBokning.Remove(masterBokning);
            //unitOfWork.MasterBokningRepository.Update(masterBokning);
            unitOfWork.Complete();
        }

    }
}
