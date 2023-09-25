using Datalager;
using Entiteter.Personer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affärslager.KundKontroller
{
    public class PrivatkundKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public void RegistreraPrivatKund(Privatkund pk)
        {
            unitOfWork.privatKundRepository.Create(pk);
        }

        public ICollection<Privatkund> SökPrivatKunder (string input)
        {
            return unitOfWork.privatKundRepository.SökPrivatKunder(input);
        }

        public ICollection<Privatkund> LäsPrivatKunder()
        {
            return unitOfWork.privatKundRepository.Read();
        }


    }
}
