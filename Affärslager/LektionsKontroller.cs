using Datalager;
using Entiteter.Enums;
using Entiteter.Personer;
using Entiteter.Tjänster;

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
        public void BokaGruppLektion(Elev elev, GruppLektion gLektion)
        {
            int elever = 15;
            if (gLektion.Deltagare.Count > elever)
            {
                gLektion.Deltagare.Add(elev);
                unitOfWork.Complete();
            }
        }
        public void BokaPrivatLektion(Elev elev, PrivatLektion pLektion)
        {
            int elever = 2;
            if (pLektion.Deltagare.Count < elever)
            {
                pLektion.Deltagare.Add(elev);
                unitOfWork.Complete();
            }
        }
        public IList<GruppLektion> AllaGruppLektion()
        {
            List<GruppLektion> AllaGruppLektion = new List<GruppLektion>();

            foreach (GruppLektion Hej in unitOfWork.GruppLektionRepository.GetAll())
            {
                AllaGruppLektion.Add(Hej);
            }
            return AllaGruppLektion;
        }
        public IList<PrivatLektion> AllaPrivatLektion()
        {
            List<PrivatLektion> AllaPrivatLektion = new List<PrivatLektion>();

            foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.GetAll())
            {
                AllaPrivatLektion.Add(Hej);
            }
            return AllaPrivatLektion;
        }
    }


}
