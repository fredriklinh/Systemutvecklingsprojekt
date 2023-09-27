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
            
        }

        //public ICollection<Privatkund> SökPrivatKunder (Privatkund input)     Kan komma att användas senare i projektet.
        //{
            //return unitOfWork.PrivatkundRepository.Find(input);
        //}
        public Privatkund SökPrivatkund (Privatkund input)
        {
            return unitOfWork.PrivatkundRepository.FirstOrDefault(a => a.PrivatkundId.Equals(input));
        }

        public ICollection<Privatkund> LäsPrivatKunder()
        {
            return unitOfWork.PrivatkundRepository.GetAll().ToList();
        }

        public void UppdateraPrivatkund(Privatkund privatkund)
        {
            unitOfWork.PrivatkundRepository.Update(privatkund);
               
        }


    }
}
