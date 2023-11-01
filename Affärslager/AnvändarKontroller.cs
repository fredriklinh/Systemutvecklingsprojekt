using Datalager;
using Datalager.Context;
using Entiteter.Personer;

namespace Affärslager
{
    public class AnvändarKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //Laddar in och poppulerar databasen med data.
        public void LaddaData()
        {
            dbContext DbContext = new dbContext();
            DbContext.Reset();
            DbContext.Database.EnsureCreated();
        }

        //Hämtar användare utifrån angivet användarnamn och lösenord
        public Användare Inloggning(string användarnamn, string lösenord)
        {
            Användare anv = unitOfWork.AnvändareRepository.FirstOrDefault(e => e.Användarnamn == användarnamn && e.Lösenord == lösenord);
            return anv;
        }

        //Hämtar alla användare 
        public List<Användare> HämtaAllaAnvändare()
        {
            return unitOfWork.AnvändareRepository.GetAll().ToList();

        }

        //Söker användare utifrån input och returnerar 
        public ICollection<Användare> SökAnvändare(string input)
        {
            var query = unitOfWork.AnvändareRepository.Find(x => x.Användarnamn.Contains(input));

            return query.ToList();
        }

        //Skapar en användare med användare som parameter
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
        
        //Tar bort användare 
        public void TaBortAnvändare(Användare användare)
        {
            unitOfWork.AnvändareRepository.Delete(användare);
            unitOfWork.Complete();
        }
    }
}
