using Datalager;
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
            if (gLektion.Deltagare.Count > 15)
            {
                gLektion.Deltagare.Add(elev);
                unitOfWork.GruppLektionRepository.Update(gLektion);
            }
            unitOfWork.Complete();
        }
        public void BokaPrivatLektion(Elev elev, PrivatLektion pLektion)
        {

            if (pLektion.Deltagare.Count < 2)
            {
                pLektion.Deltagare.Add(elev);
                unitOfWork.PrivatLektionRepository.Update(pLektion);
            }
            unitOfWork.Complete();
        }
        public IList<GruppLektion> AllaGruppLektion()
        {
            IList<GruppLektion> AllaGruppLektion = new List<GruppLektion>();

            foreach (GruppLektion Hej in unitOfWork.GruppLektionRepository.GetAll())
            {
                AllaGruppLektion.Add(Hej);

            }
            return AllaGruppLektion;
        }
        public IList<PrivatLektion> AllaPrivatLektion()
        {
            IList<PrivatLektion> AllaPrivatLektion = new List<PrivatLektion>();

            foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.GetAll())
            {
                AllaPrivatLektion.Add(Hej);
            }
            return AllaPrivatLektion;
        }
        public IList<Elev> HämtaDeltagareFrånLektionG(GruppLektion gLektion)
        {
            IList<Elev> eleverILektionen = new List<Elev>();

            foreach (Elev e in gLektion.Deltagare)
            {
                eleverILektionen.Add(e);
            }
            return eleverILektionen;
        }

        public IList<Elev> HämtaDeltagareFrånLektionP(PrivatLektion pLektion)
        {
            IList<Elev> eleverILektionen = new List<Elev>();

            foreach (Elev e in pLektion.Deltagare)
            {
                eleverILektionen.Add(e);
            }
            return eleverILektionen;
        }
    }
}
