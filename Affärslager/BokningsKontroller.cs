using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalager;
using Datalager.Context;
using Entiteter;

namespace Affärslager
{
    public  class BokningsKontroller
    {

        UnitOfWork unitOfWork = new UnitOfWork();



        //public Kontroller() { }

        public UnitOfWork UnitOfWork
        {
            get => default;
            set
            {
            }
        }

        //public DataLayer.InterfaceRepository.Repository<object> Repository
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}



        public void LaddaData()
        {
            dbContext DbContext = new dbContext();
            DbContext.Reset();
            DbContext.Database.EnsureCreated();
        }


    }
}
