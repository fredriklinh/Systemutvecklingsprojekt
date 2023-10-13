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

        public IList<Utrustning> HämtaTillgängligUtrustningTyp()
        {

            
            List<Utrustning> AllaUtrustningar = new List<Utrustning>();

            foreach (Utrustning Hej in unitOfWork.UtrustningRepository.GetAll())
            {
                AllaUtrustningar.Add(Hej);
            }
            return AllaUtrustningar;
        }



        public List<Utrustning> SökBenämningTyp(string benämning, string typ)
        {
            List<Utrustning> utrustningAvTyp = new List<Utrustning>();

            foreach (Utrustning utr in unitOfWork.UtrustningRepository.Find(k => k.Typ.Equals(typ) && k.Benämning.Equals(benämning)))
            {

                utrustningAvTyp.Add(utr);
            }
            return utrustningAvTyp;
        }

        public List<Utrustning> SökBenämning(string utrBenämning)
        {
            //var querable = unitOfWork.UtrustningRepository.Find().Where(a => a.Typ == utrBenämning);
            
            List<Utrustning> loo = new List<Utrustning>();

            foreach (Utrustning item in unitOfWork.UtrustningRepository.Find(a => a.Typ == utrBenämning))
            {
                loo.Add(item);
            }
            int hej = 0;
           //return querable
           //         .Where(i => i.Typ == utrBenämning.Typ)
           //         .Distinct()
           //         .ToList();
            return loo
                    .GroupBy(i => i.Benämning)
                    .Select(group => group.First())
                    .ToList();
        }


        public IList<Utrustning> SökTyp(Utrustning SelectedItem)
        {
            var querable = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Benämning == SelectedItem.Benämning);
            
            return querable
                        .GroupBy(i => i.Benämning)
                        .Select(group => group.First())
                        .ToList();
        }
    }
}
