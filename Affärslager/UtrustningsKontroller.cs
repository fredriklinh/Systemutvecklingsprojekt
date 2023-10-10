using Datalager;
using Entiteter.Tjänster;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Affärslager
{
    public class UtrustningsKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public IList<Utrustning> HämtaTillgängligUtrustning()
        {
            List<Utrustning> AllaUtrustningar = new List<Utrustning>();

            foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
            {
                AllaUtrustningar.Add(Hej);
            }
            return AllaUtrustningar;
        }



        //public IList<Utrustning> SökBenämningTyp(string benämning, string typ)
        //{
        //    List<Utrustning> AllaUtrustningar = new List<Utrustning>();

        //    foreach (Utrustning i in unitOfWork.UtrustningRepository.GetAll().Where(a => a.Benämning == benämning && a.Typ == typ).)
        //    {

        //        AllaUtrustningar.Add(i);
        //    }
        //    return AllaUtrustningar;
        //}




    }
}
