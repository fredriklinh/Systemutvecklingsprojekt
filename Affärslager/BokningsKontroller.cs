using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalager;
using Datalager.Context;
using Entiteter;
using Entiteter.Personer;
using Entiteter.Tjänster;


namespace Affärslager
{
    public  class BokningsKontroller
    {

        UnitOfWork unitOfWork = new UnitOfWork();

        /// <summary>
        /// Metoden kollar igenom alla logier mellan två angivna datum som har status tillgänglig true samt kollar igenom alla bokade logier som är utanför angivet datum f
        /// </summary>
        /// <param name="startdatum"></param>
        /// <param name="slutdatum"></param>
        /// <returns></returns>
        public List<Logi> HämtaTillgängligLogi (DateTime startdatum, DateTime slutdatum)
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

        public void SkapaMasterbokningPrivatkund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Privatkund privatkund/*, Användare användare*/)
        {
            
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, privatkund /*användare*/);
            unitOfWork.MasterBokningRepository.Add(masterBokning);
            unitOfWork.Complete();
        }




    }
}
