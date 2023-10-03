using Datalager;
using Entiteter.Personer;

namespace Affärslager.KundKontroller
{
    public class FöretagskundKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public Företagskund RegistreraFöretagskund(double maxBeloppsKreditGränds, string adress, string postnummer, string ort, string telefonnummer, string mailAdress, string orgNr, string företagsNamn, double rabattSats)
        {

            Företagskund företagskund = new Företagskund(maxBeloppsKreditGränds, adress, postnummer, ort, telefonnummer, mailAdress, orgNr, företagsNamn, rabattSats);
            unitOfWork.FöretagskundRepository.Add(företagskund);
            unitOfWork.Complete();
            return företagskund;
        }

        //public bool KontrollFKund(string orgnr)
        //{
        //    Företagskund k = unitOfWork.FöretagskundRepository.FirstOrDefault(f => f.OrgNr == orgnr);
        //    bool x;
        //    if (k != null)
        //    {
        //        x = false;
        //    }
        //    else
        //    {
        //        x = true;
        //    }
        //    return x;
        //}

        //OBS. FUNKTION ENDAST FÖR ADMIN
        public Företagskund TaBortFöretagskund(string OrgNummer)
        {
            Företagskund företag = unitOfWork.FöretagskundRepository.FirstOrDefault(a => a.OrgNr.Equals(OrgNummer));
            unitOfWork.FöretagskundRepository.Delete(företag);
            unitOfWork.Complete();
            //Dena return är för att visa presentationslager att bortttagning lyckades
            return företag;

        }

        public Företagskund SökFöretagskund(string input)
        {
            return unitOfWork.FöretagskundRepository.FirstOrDefault(a => a.OrgNr.Equals(input));
        }

        public ICollection<Företagskund> LäsPrivatKunder()
        {
            return unitOfWork.FöretagskundRepository.GetAll().ToList();
        }
    }
}
