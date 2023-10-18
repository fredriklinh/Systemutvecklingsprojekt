using Datalager;
using Entiteter.Personer;
using Entiteter.Prislistor;
using Entiteter.Tjänster;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Globalization;

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
            if (gLektion.Deltagare.Count < 15)
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
        public void AvBokaPrivatLektion(Elev elev, PrivatLektion pLektion)
        {
            pLektion.Deltagare.Remove(elev);
            unitOfWork.ElevRepository.Delete(elev);
            unitOfWork.ElevRepository.Update(elev);
            unitOfWork.PrivatLektionRepository.Update(pLektion);
            unitOfWork.Complete();
        }
        public void AvBokaGruppLektion(Elev elev, GruppLektion gLektion)
        {
            gLektion.Deltagare.Remove(elev);
            unitOfWork.ElevRepository.Delete(elev);
            unitOfWork.ElevRepository.Update(elev);
            unitOfWork.GruppLektionRepository.Update(gLektion);
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



        public IList<Object> HämtaAktuellaLektioner(IList<PrivatLektion> pL, IList<GruppLektion> gL)
        {
            IList<Object> AllaLektioner = pL.Cast<Object>().Concat(gL).ToList();
            return AllaLektioner;
        }

        public int RäknaAntalDeltagareP(IList<Object> AllaLektioner)
        {
            IList<Elev> elever = new List<Elev>();
            int elevAntal = 0;
                if (AllaLektioner.Contains(elever))
                {
                    foreach (Elev e in elever)
                    {
                    elevAntal = elevAntal + 1;
                    }

            }
            return elevAntal;
        }



        public IList<GruppLektion> AktuellaGruppLektioner(DateTime inDatum)
        {
            IList<GruppLektion> AllaGruppLektion = new List<GruppLektion>();

            if (inDatum.DayOfWeek.Equals(DayOfWeek.Monday) || inDatum.DayOfWeek.Equals(DayOfWeek.Tuesday) || inDatum.DayOfWeek.Equals(DayOfWeek.Wednesday))

                foreach (GruppLektion Hej in unitOfWork.GruppLektionRepository.Find(gL => gL.LektionsTillfälle.Contains("Mån") && gL.Deltagare.Count < 15))
                {
                    AllaGruppLektion.Add(Hej);
                }
            else
            {
                foreach (GruppLektion Hej in unitOfWork.GruppLektionRepository.Find(gL => gL.LektionsTillfälle.Contains("Tors") && gL.Deltagare.Count < 15))
                {
                    AllaGruppLektion.Add(Hej);
                }
            }
            
            return AllaGruppLektion;
        }
        public IList<PrivatLektion> AktuellaPrivatLektioner(DateTime inDatum)
        {
            IList<PrivatLektion> AllaPrivatLektion = new List<PrivatLektion>();

            if (inDatum.DayOfWeek.Equals(DayOfWeek.Monday))

                foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Mån") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(Hej);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Tuesday))

                foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Tis") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(Hej);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Wednesday))

                foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Ons") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(Hej);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Thursday))

                foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Tors") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(Hej);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Friday))

                foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Fre") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(Hej);
                }
            return AllaPrivatLektion;
        }
    }
}
