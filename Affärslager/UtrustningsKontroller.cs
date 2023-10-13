using Datalager;
using Entiteter.Tjänster;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;

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



        public ObservableCollection<int> SökBenämningTyp(string benämning, string typ)
        {
            List<Utrustning> utrustningAvTyp = new List<Utrustning>();

            foreach (Utrustning utr in unitOfWork.UtrustningRepository.Find(k => k.Typ.Equals(typ) && k.Benämning.Equals(benämning)))
            {

                utrustningAvTyp.Add(utr);
            }
            return RäknaAntal(utrustningAvTyp);
        }

        private ObservableCollection<int> RäknaAntal(List<Utrustning> utrustnings)
        {
            ObservableCollection<int> antal = new ObservableCollection<int>();
            int steg = 0;
            foreach (Utrustning item in utrustnings)
            {
                if (steg == 50)
                {
                    return antal;
                }
                steg = steg + 1;
                antal.Add(steg);
            }
            return antal;
        }

        public List<Utrustning> SökBenämning(string utrBenämning)
        {
            var querable = unitOfWork.UtrustningRepository.GetAll().Where(a => a.Typ == utrBenämning);

            return querable
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
