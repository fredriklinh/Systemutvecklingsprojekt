using Datalager;
using Datalager.Context;
using Entiteter.Personer;

namespace Affärslager
{
    public class AnvändarKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public void LaddaData()
        {
            dbContext DbContext = new dbContext();
            DbContext.Reset();
            DbContext.Database.EnsureCreated();
        }

        public Användare Inloggning(string användarnamn, string lösenord)
        {
            Användare anv = unitOfWork.AnvändareRepository.FirstOrDefault(e => e.Användarnamn == användarnamn && e.Lösenord == lösenord);
            return anv;
        }

        public List<Användare> HämtaAllaAnvändare()
        {
            return unitOfWork.AnvändareRepository.GetAll().ToList();

        }

        public ICollection<Användare> SökAnvändare(string input)
        {
            var query = unitOfWork.AnvändareRepository.Find(x => x.Användarnamn.Contains(input));

            return query.ToList();
        }
        public void SkapaAnvändare(Användare användare)
        {
            //Todo
            //Skapa konstruktur i entitet användare och ta in alla parametrar i metoder
            unitOfWork.AnvändareRepository.Add(användare);
            unitOfWork.Complete();
        }
        //public void UppdateraAnvändare(Användare användare)
        //{
        //    unitOfWork.AnvändareRepository.Update(användare);
        //    unitOfWork.Complete();
        //}
        public void TaBortAnvändare(Användare användare)
        {
            unitOfWork.AnvändareRepository.Delete(användare);
            unitOfWork.Complete();
        }
    }
}
