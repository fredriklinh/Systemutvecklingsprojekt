using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entiteter.Prislistor;
using Entiteter.Tjänster;
using Entiteter.Personer;
using Datalager;

namespace Affärslager
{
    public class UtrustningsKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public List<Utrustning> HämtaTillgängligUtrustning()
        {
            List<Utrustning> utrustning = new List<Utrustning>();

            foreach (Utrustning allUtrustning in unitOfWork.UtrustningRepository.Find(b => b.Tillgänglig))
            {
                utrustning.Add(allUtrustning);
            }
            //foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(f => startdatum >= f.SlutDatum || slutdatum <= f.StartDatum))
            //{
            //    foreach (Logi ledigLogi in item.ValdLogi)
            //    {
            //        logi.Add(ledigLogi);
            //    }
            //}
            return utrustning;
        }


    }
}
