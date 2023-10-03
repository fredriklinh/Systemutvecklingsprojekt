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

        public Privatkund RegistreraFöretagskund(string adress, string postnummer, string ort, string telefonnummer, string mailAdress, string personnummer, string förnamn, string efternamn)
        {
            Privatkund privatkund = new Privatkund(adress, postnummer, ort, telefonnummer, mailAdress, personnummer, förnamn, efternamn);
            unitOfWork.PrivatkundRepository.Add(privatkund);
            unitOfWork.Complete();
            return privatkund;
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
