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

            Utrustning utr = unitOfWork.UtrustningRepository.FirstOrDefault(a => a.UtrustningsTyp.Typ == "Alpint");
           
        }


    }
}
