using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;


namespace Affärslager
{
    public class BokningsKontroller
    {

        UnitOfWork unitOfWork = new UnitOfWork();

        /// <summary>
        /// Metoden kollar igenom alla logier mellan två angivna datum som har status tillgänglig true samt kollar igenom alla bokade logier som är utanför angivet datum f
        /// </summary>
        /// <param name="startdatum"></param>
        /// <param name="slutdatum"></param>
        /// <returns></returns>
        public List<Logi> HämtaTillgängligLogi(DateTime startdatum, DateTime slutdatum)
        {
            List<Logi> logi = new List<Logi>();

            foreach (Logi allLogi in unitOfWork.LogiRepository.Find(b => b.ÄrTillgänglig))
            {
                logi.Add(allLogi);
            }
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(f => startdatum >= f.SlutDatum || slutdatum <= f.StartDatum))
            {
                foreach (Logi ledigLogi in item.ValdLogi)
                {
                    logi.Add(ledigLogi);
                }
            }
            return logi;
        }

        public MasterBokning SkapaMasterbokningPrivatkund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Privatkund privatkund, Användare användare)
        {
            Privatkund privatkund1 = unitOfWork.PrivatkundRepository.FirstOrDefault(pk => pk.Personnummer.Equals(privatkund.Personnummer));
            Användare användare1 = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.AnvändarID.Equals(användare.AnvändarID));
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, privatkund1, användare1);
            unitOfWork.MasterBokningRepository.Add(masterBokning);
            unitOfWork.Complete();
            return masterBokning;
        }

        public MasterBokning SkapaMasterbokningFöretagskund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Företagskund företagskund, Användare användare)
        {
            Företagskund företagskund1 = unitOfWork.FöretagskundRepository.FirstOrDefault(fk => fk.OrgNr.Equals(företagskund.OrgNr));
            Användare användare1 = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.AnvändarID.Equals(användare.AnvändarID));
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, företagskund1, användare1);
            unitOfWork.MasterBokningRepository.Add(masterBokning);
            unitOfWork.Complete();
            return masterBokning;
        }

        //Söker först igenom bokningar på privatkunder om inget hittas söker vi på företagskunder och returnerar
        public List<MasterBokning> HämtaMasterbokningar(string kundnummer)
        {
            List<MasterBokning> masterbokningar = new List<MasterBokning>();

            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(pmb => pmb.PersonNr.Equals(kundnummer)))
            {
                masterbokningar.Add(item);
            }
            if (masterbokningar == null)
            {
                foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(fmb => fmb.OrgaNr.Equals(kundnummer)))
                {
                    masterbokningar.Add(item);
                }
            }
            // TODO ? VIll vi söka på bokningsnummer också?
            //if (masterbokningar == null)
            //{
            //    foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(bNr => bNr.BokningsNr.Equals(kundnummer)))
            //    {
            //        masterbokningar.Add(item);
            //    }
            //}
            return masterbokningar;
        }

        public List<MasterBokning> HämtaMasterbokningarFöretag(string OrgNr)
        {
            List<MasterBokning> företagMasterbokning = new List<MasterBokning>();

            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(kl => kl.OrgaNr.Equals(OrgNr)))
            {
                företagMasterbokning.Add(item);
            }
            return företagMasterbokning;
        }

        public void SparaÄndring(MasterBokning masterBokning)
        {
            unitOfWork.MasterBokningRepository.Update(masterBokning);
            unitOfWork.Complete();
        }
    }
}
