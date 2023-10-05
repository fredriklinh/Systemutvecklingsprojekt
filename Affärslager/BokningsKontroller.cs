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
            List<Logi> AllaLogi = new List<Logi>();

            //foreach (Logi allLogi in unitOfWork.LogiRepository.Find(b => b.ÄrTillgänglig))
            //{
            //    logi.Add(allLogi);
            //}

            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(f => startdatum >= f.SlutDatum || slutdatum <= f.StartDatum || slutdatum <= f.StartDatum && startdatum >= f.SlutDatum))
            {
                foreach (Logi logit in item.ValdLogi)
                {
                    logit.Bokad();
                    unitOfWork.Complete();
                }
                foreach (Logi ledigLogi in AllaLogi)
                {
                    AllaLogi.Add(ledigLogi);
                }
            }
            return AllaLogi;
        }
        public void BaraKör()
        {

            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.GetAll().ToList())
            {
                foreach(Logi logit in item.ValdLogi)
                logit.Tillgänlig();
                unitOfWork.Complete();
            }
        }

        public MasterBokning SkapaMasterbokningPrivatkund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Privatkund privatkund, Användare användare)
        {
            Privatkund privatkund1 = unitOfWork.PrivatkundRepository.FirstOrDefault(pk => pk.Personnummer.Equals(privatkund.Personnummer));
            Användare användare1 = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.AnvändarID.Equals(användare.AnvändarID));
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, privatkund1, användare1);
            //foreach (Logi logi in masterBokning.ValdLogi)
            //{
            //    logi.Bokad();
            //}

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






}
}
