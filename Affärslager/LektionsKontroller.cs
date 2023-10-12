using Datalager;
using Datalager.Context;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Entiteter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affärslager
{
    public class LektionsKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public Elev RegistreraElev(string förnamn, string efternamn)
        {
            Elev elev = new Elev(förnamn, efternamn);
            unitOfWork.ElevRepository.Add(elev);
            unitOfWork.Complete();
            return elev;
        }
        public GruppLektion BokaGruppLektion(Elev elev, string lektionsTillfälle, Svårighetsgrad svårighetsgrad)
        {
            GruppLektion gruppLektion = unitOfWork.GruppLektionRepository.FirstOrDefault(a => a.LektionsTillfälle == lektionsTillfälle && a.Svårighetsgrad == svårighetsgrad);
            gruppLektion.Deltagare.Add(elev);
            unitOfWork.Complete();
            return gruppLektion;           
        }
        public PrivatLektion BokaPrivatLektion(Elev elev, string lektionstillfälle)
        {
            PrivatLektion privatLektion = unitOfWork.PrivatLektionRepository.FirstOrDefault(a => a.LektionsTillfälle == lektionstillfälle);
            int elever = 2;
            if (privatLektion.Deltagare.Count < elever)
            {
                privatLektion.Deltagare.Add(elev);
            }            
            return privatLektion;
        }
        
    }
}
