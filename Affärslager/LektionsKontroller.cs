using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;

namespace Affärslager
{
    public class LektionsKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //Registrerar elev med parametrar förnam och efternamn
        public Elev RegistreraElev(string förnamn, string efternamn)
        {
            Elev elev = new Elev(förnamn, efternamn);
            unitOfWork.ElevRepository.Add(elev);
            unitOfWork.Complete();
            return elev;
        }

        //Kollar om grupplektion innehåller maxantal. Annars Bokas Elev till angiven Grupplektion. 
        public void BokaGruppLektion(Elev elev, GruppLektion gLektion, MasterBokning mB)
        {
            if (gLektion.Deltagare.Count < 15)
            {
                mB.GruppLektioner.Add(gLektion);
                gLektion.Deltagare.Add(elev);
                //unitOfWork.GruppLektionRepository.Update(gLektion);
                //unitOfWork.MasterBokningRepository.Update(mB);
            }
            unitOfWork.Complete();
        }

        //Kollar om privatlektion innehåller maxantal. Annars Bokas Elev till angiven privatlektion. 
        public void BokaPrivatLektion(Elev elev, PrivatLektion pLektion, MasterBokning mB)
        {

            if (pLektion.Deltagare.Count < 2)
            {
                mB.PrivatLektioner.Add(pLektion);
                pLektion.Deltagare.Add(elev);
                //unitOfWork.PrivatLektionRepository.Update(pLektion);
                //unitOfWork.MasterBokningRepository.Update(mB);
            }
            unitOfWork.Complete();
        }

        //Avbokar Privatlektion med angiven elev och privatlektion. 
        public void AvBokaPrivatLektion(Elev elev, PrivatLektion pLektion, MasterBokning mB)
        {
            pLektion.Deltagare.Remove(elev);
            mB.PrivatLektioner.Remove(pLektion);
            unitOfWork.ElevRepository.Delete(elev);
            //unitOfWork.ElevRepository.Update(elev);
            //unitOfWork.PrivatLektionRepository.Update(pLektion);
            //unitOfWork.MasterBokningRepository.Update(mB);
            unitOfWork.Complete();
        }


        //Avbokar Grupplektion med angiven Elev och Grupplektion. 
        public void AvBokaGruppLektion(Elev elev, GruppLektion gLektion, MasterBokning mB)
        {
            gLektion.Deltagare.Remove(elev);
            mB.GruppLektioner.Remove(gLektion);
            unitOfWork.ElevRepository.Delete(elev);
            //unitOfWork.ElevRepository.Update(elev);
            //unitOfWork.GruppLektionRepository.Update(gLektion);
            //unitOfWork.MasterBokningRepository.Update(mB);
            unitOfWork.Complete();
        }

        //Hämtar alla grupplektioner och returnerar AllaGrupplektioner
        public IList<GruppLektion> AllaGruppLektion()
        {
            IList<GruppLektion> AllaGruppLektion = new List<GruppLektion>();

            foreach (GruppLektion Hej in unitOfWork.GruppLektionRepository.GetAll())
            {
                AllaGruppLektion.Add(Hej);

            }
            return AllaGruppLektion;
        }


        //Hämtar alla privatlektioner och returnerar AllaPrivatlektioner
        public IList<PrivatLektion> AllaPrivatLektion()
        {
            IList<PrivatLektion> AllaPrivatLektion = new List<PrivatLektion>();

            foreach (PrivatLektion Hej in unitOfWork.PrivatLektionRepository.GetAll())
            {
                AllaPrivatLektion.Add(Hej);
            }
            return AllaPrivatLektion;
        }

        //Hämtar elever från grupplektion och returnerar dessa i en lista
        public IList<Elev> HämtaDeltagareFrånLektionG(GruppLektion gLektion)
        {
            IList<Elev> eleverILektionen = new List<Elev>();

            foreach (Elev e in gLektion.Deltagare)
            {
                eleverILektionen.Add(e);
            }
            return eleverILektionen;
        }


        //Hämtar Deltagare från privatlektion och returnerar dessa i en lista 
        public IList<Elev> HämtaDeltagareFrånLektionP(PrivatLektion pLektion)
        {
            IList<Elev> eleverILektionen = new List<Elev>();

            foreach (Elev e in pLektion.Deltagare)
            {
                eleverILektionen.Add(e);
            }
            return eleverILektionen;
        }


        //Adderar alla aktuella privatlektion och grupplektioner i en och samma lista och returnerar dessa.
        public IList<Object> HämtaAktuellaLektioner(IList<PrivatLektion> pL, IList<GruppLektion> gL)
        {
            IList<Object> AllaLektioner = pL.Cast<Object>().Concat(gL).ToList();
            return AllaLektioner;
        }


        //EJ AKTIV - Tanken är för en pristuträkning på alla lektioner totalt
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



        //Tittar på de aktuella GruppLektioner och hämtar de beroende på dagar och datum
        public IList<GruppLektion> AktuellaGruppLektioner(DateTime inDatum)
        {
            IList<GruppLektion> AllaGruppLektion = new List<GruppLektion>();

            if (inDatum.DayOfWeek.Equals(DayOfWeek.Monday) || inDatum.DayOfWeek.Equals(DayOfWeek.Tuesday) || inDatum.DayOfWeek.Equals(DayOfWeek.Wednesday))

                foreach (GruppLektion glektion in unitOfWork.GruppLektionRepository.Find(gL => gL.LektionsTillfälle.Contains("Mån") && gL.Deltagare.Count < 15))
                {
                    AllaGruppLektion.Add(glektion);
                }

            if (inDatum.DayOfWeek.Equals(DayOfWeek.Friday) || inDatum.DayOfWeek.Equals(DayOfWeek.Thursday))
            {
                foreach (GruppLektion grupplektion in unitOfWork.GruppLektionRepository.Find(gL => gL.LektionsTillfälle.Contains("Tors") && gL.Deltagare.Count < 15))
                {
                    AllaGruppLektion.Add(grupplektion);
                }
            }
            return AllaGruppLektion;
        }

        //Tittar på de aktulla privatlektioner och hämtar de beroende på dagar och datum
        public IList<PrivatLektion> AktuellaPrivatLektioner(DateTime inDatum)
        {
            IList<PrivatLektion> AllaPrivatLektion = new List<PrivatLektion>();

            if (inDatum.DayOfWeek.Equals(DayOfWeek.Monday))

                foreach (PrivatLektion mån in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Mån") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(mån);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Tuesday))

                foreach (PrivatLektion tis in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Tis") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(tis);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Wednesday))

                foreach (PrivatLektion ons in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Ons") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(ons);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Thursday))

                foreach (PrivatLektion tors in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Tors") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(tors);
                }
            if (inDatum.DayOfWeek.Equals(DayOfWeek.Friday))

                foreach (PrivatLektion fre in unitOfWork.PrivatLektionRepository.Find(pL => pL.LektionsTillfälle.Contains("Fre") && pL.Deltagare.Count < 2))
                {
                    AllaPrivatLektion.Add(fre);
                }
            return AllaPrivatLektion;
        }

        //hämtar masterbokning utifrån angiven söknings
        public MasterBokning HämtaKundsMasterBokning(string sökning)
        {
            MasterBokning item = unitOfWork.MasterBokningRepository.FirstOrDefault(kl => kl.PersonNr == sökning || kl.OrgaNr == sökning);
            return item;
        }

        //Metod för att beräkna om kund ska tillåtaslägga bokning på kredit eller ej. Returnerar true eller false
        public bool TillåtEjKredit(double kreditTotalKund, double summaBokning, MasterBokning masterBokning)
        {
            if (masterBokning.NyttjadKreditsumma + summaBokning >= kreditTotalKund)
            {
                return false;

            }
            else return true;
        }


        //Lägger till den bokade kostnad på nyttjadkredit på masterbokning på antingen privatkund eller företagskund.
        public MasterBokning FixaPrisLektion(double summa, bool påKredit, MasterBokning mB)
        {
            if (mB.OrgaNr != null)
            {
                Företagskund fk = unitOfWork.FöretagskundRepository.FirstOrDefault(a => a.OrgNr.Equals(mB.OrgaNr));
                if (påKredit == true)
                {
                    mB.NyttjadKreditsumma += summa;
                }
            }

            if (mB.PersonNr != null)
            {
                Privatkund pk = unitOfWork.PrivatkundRepository.FirstOrDefault(m => m.Personnummer.Equals(mB.PersonNr));
                if (påKredit == true)
                {
                    mB.NyttjadKreditsumma += summa;
                }
            }
            unitOfWork.Complete();
            return mB;
            
        }
    }
}
