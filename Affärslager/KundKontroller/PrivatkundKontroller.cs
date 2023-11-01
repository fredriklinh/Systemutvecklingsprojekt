using Datalager;
using Entiteter.Personer;

namespace Affärslager.KundKontroller
{
    public class PrivatkundKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //Registrerar privatkund med input
        public Privatkund RegistreraPrivatKund(string personnummer, string postnummer, string ort, string telefonnummer, string mailAdress, string adress, string förnamn, string efternamn)
        {
            Privatkund privatkund = new Privatkund(personnummer, postnummer, ort, telefonnummer, mailAdress, adress, förnamn, efternamn);
            unitOfWork.PrivatkundRepository.Add(privatkund);
            unitOfWork.Complete();
            return privatkund;
        }

        //public ICollection<Privatkund> SökPrivatKunder (Privatkund input)     Kan komma att användas senare i projektet.
        //{
        //return unitOfWork.PrivatkundRepository.Find(input);
        //}

        //Söker privatkund beroende på input
        public Privatkund SökPrivatkund(string input)
        {
            return unitOfWork.PrivatkundRepository.FirstOrDefault(a => a.Personnummer.Equals(input));
        }

        //Läser in och hämtar alla privatkunder
        public ICollection<Privatkund> LäsPrivatKunder()
        {
            return unitOfWork.PrivatkundRepository.GetAll().ToList();
        }

        //Uppdaterar privatkundsinformation som ändrats - ej aktiv
        public void UppdateraPrivatkund(Privatkund privatkund)
        {
            unitOfWork.PrivatkundRepository.Update(privatkund);

        }


    }
}
