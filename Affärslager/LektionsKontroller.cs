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

        public void BokaGruppLektion(Elev elev, GruppLektion gLektion, MasterBokning mB)
        {
            if (gLektion.Deltagare.Count < 15)
            {
                mB.GruppLektioner.Add(gLektion);
                gLektion.Deltagare.Add(elev);
                unitOfWork.GruppLektionRepository.Update(gLektion);
                unitOfWork.MasterBokningRepository.Update(mB);
            }
            unitOfWork.Complete();
        }
        public void BokaPrivatLektion(Elev elev, PrivatLektion pLektion, MasterBokning mB)
        {

            if (pLektion.Deltagare.Count < 2)
            {
                mB.PrivatLektioner.Add(pLektion);
                pLektion.Deltagare.Add(elev);
                unitOfWork.PrivatLektionRepository.Update(pLektion);
                unitOfWork.MasterBokningRepository.Update(mB);
            }
            unitOfWork.Complete();
        }
        public void AvBokaPrivatLektion(Elev elev, PrivatLektion pLektion, MasterBokning mB)
        {
            pLektion.Deltagare.Remove(elev);
            mB.PrivatLektioner.Remove(pLektion);
            unitOfWork.ElevRepository.Delete(elev);
            unitOfWork.ElevRepository.Update(elev);
            unitOfWork.PrivatLektionRepository.Update(pLektion);
            unitOfWork.MasterBokningRepository.Update(mB);
            unitOfWork.Complete();
        }
        public void AvBokaGruppLektion(Elev elev, GruppLektion gLektion, MasterBokning mB)
        {
            gLektion.Deltagare.Remove(elev);
            mB.GruppLektioner.Remove(gLektion);
            unitOfWork.ElevRepository.Delete(elev);
            unitOfWork.ElevRepository.Update(elev);
            unitOfWork.GruppLektionRepository.Update(gLektion);
            unitOfWork.MasterBokningRepository.Update(mB);
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

            if (inDatum.DayOfWeek.Equals(DayOfWeek.Friday) || inDatum.DayOfWeek.Equals(DayOfWeek.Thursday))
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

        public MasterBokning HämtaKundsMasterBokning(string sökning)
        {

            MasterBokning item = unitOfWork.MasterBokningRepository.FirstOrDefault(kl => kl.PersonNr == sökning || kl.OrgaNr == sökning);
            return item;
        }






        public MasterBokning KollaKredtiTotal(double kreditTotalKund, double summaBokning, MasterBokning masterBokning)
        {
            //SKA TESTAS
            masterBokning.NyttjadKreditsumma += summaBokning;
            if (masterBokning.NyttjadKreditsumma + summaBokning <= kreditTotalKund)
            {
                unitOfWork.Complete();
                return masterBokning;

            }
            else return masterBokning;
        }

        public MasterBokning FixaPrisLektion(double summa, bool påKredit, MasterBokning mB)
        {
            if (mB.OrgaNr != null)
            {
                Företagskund fk = unitOfWork.FöretagskundRepository.FirstOrDefault(a => a.OrgNr.Equals(mB.OrgaNr));
                if (påKredit == true) KollaKredtiTotal(fk.MaxBeloppsKreditGräns, summa, mB);
                if (mB.NyttjadKreditsumma > fk.MaxBeloppsKreditGräns) return mB;
            }

            if (mB.PersonNr != null)
            {
                Privatkund pk = unitOfWork.PrivatkundRepository.FirstOrDefault(m => m.Personnummer.Equals(mB.PersonNr));
                if (påKredit == true) KollaKredtiTotal(pk.MaxBeloppsKreditGräns, summa, mB);
                if (mB.NyttjadKreditsumma > pk.MaxBeloppsKreditGräns) return mB;

            }
            unitOfWork.Complete();
            return mB;
        }
    }
}
