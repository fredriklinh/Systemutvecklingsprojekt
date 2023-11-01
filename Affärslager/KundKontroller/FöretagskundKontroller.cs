using Datalager;
using Entiteter.Personer;

namespace Affärslager.KundKontroller
{
    public class FöretagskundKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //Registrerar privatkung
        public Företagskund RegistreraFöretagskund(double maxBeloppsKreditGränds, string adress, string postnummer, string ort, string telefonnummer, string mailAdress, string orgNr, string företagsNamn, double rabattSats)
        {

            Företagskund företagskund = new Företagskund(maxBeloppsKreditGränds, adress, postnummer, ort, telefonnummer, mailAdress, orgNr, företagsNamn, rabattSats);
            unitOfWork.FöretagskundRepository.Add(företagskund);
            unitOfWork.Complete();
            return företagskund;
        }

        //Kontrollerar företagskund
        public void KontrollFKund(string orgnr, bool x)
        {
            Företagskund k = unitOfWork.FöretagskundRepository.FirstOrDefault(f => f.OrgNr == orgnr);

            if (k == null)
            {
                x = false;
            }
            else
            {
                x = true;
            }
        }

       
        //Tar bort företagskund beroende på input
        public Företagskund TaBortFöretagskund(string OrgNummer)
        {
            Företagskund företag = unitOfWork.FöretagskundRepository.FirstOrDefault(a => a.OrgNr.Equals(OrgNummer));
            unitOfWork.FöretagskundRepository.Delete(företag);
            unitOfWork.Complete();
            //Dena return är för att visa presentationslager att bortttagning lyckades
            return företag;

        }

        //Söker företagskund utifråninput
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
