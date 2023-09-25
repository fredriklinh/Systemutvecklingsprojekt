using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalager;
using Datalager.Context;
using Entiteter;
using Entiteter.Personer;

namespace Affärslager
{
    public  class BokningsKontroller
    {

        UnitOfWork unitOfWork = new UnitOfWork();



        //public Kontroller() { }



        //public DataLayer.InterfaceRepository.Repository<object> Repository
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}

        public Användare Inloggning(string användarnamn, string lösenord)
        {
            Användare anv = unitOfWork.AnvändareRepository.FirstOrDefault(e => e.Användarnamn == användarnamn && e.Lösenord == lösenord);
            return anv;
        }


        public void LaddaData()
        {
            dbContext DbContext = new dbContext();
            DbContext.Reset();
            DbContext.Database.EnsureCreated();
        }


    }
}
