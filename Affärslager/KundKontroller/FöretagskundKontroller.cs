using Datalager;
using Entiteter.Personer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affärslager.KundKontroller
{
    public class FöretagskundKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public Företagskund RegistreraFöretagskund(double maxBeloppsKreditGränds, string adress, string postnummer, string ort, string telefonnummer, string mailAdress, string orgNr, string företagsNamn, double rabattSats)
        {
            Företagskund företagskund = new Företagskund(maxBeloppsKreditGränds, adress, postnummer, ort, telefonnummer, mailAdress, orgNr, företagsNamn,rabattSats);
            unitOfWork.FöretagskundRepository.Add(företagskund);
            unitOfWork.Complete();
            return företagskund;
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
