using Datalager;
using Datalager.Context;
using Entiteter.Personer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
