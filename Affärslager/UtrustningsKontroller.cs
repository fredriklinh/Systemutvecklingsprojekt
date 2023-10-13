using Datalager;
using Entiteter.Tjänster;

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



        //public List<Utrustning> SökBenämningTyp()
        //{
        //    List<Utrustning> AllaUtrustningar = new List<Utrustning>();

        //    foreach (Utrustning i in unitOfWork.UtrustningRepository.GetAll().Distinct().ToList();.Where(a => a.Benämning == "Alpint" && a.Typ == "Pjäxor"));
        //    {
        //        AllaUtrustningar.Add(i);
        //    }
        //    return AllaUtrustningar;
        //}




    }
}
