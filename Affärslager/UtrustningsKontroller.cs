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

        public IList<Utrustning> HämtaTillgängligUtrustning()
        {
            List<Utrustning> AllaUtrustningar = new List<Utrustning>();

            foreach(Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
            {
                AllaUtrustningar.Add(Hej);
            }
            return AllaUtrustningar;
        }
    }
}
