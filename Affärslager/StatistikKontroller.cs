using Datalager;
using Entiteter.Tjänster;

namespace Affärslager
{
    public class StatistikKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        #region StatistikLogi

        public IList<MasterBokning> HämtaAllaBokningar(int år)
        {
            List<MasterBokning> MS = new List<MasterBokning>();
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(a => a.StartDatum.Year.Equals(år)))
            {
                MS.Add(item);
            }
            
            return MS;
        }

        public List<MasterBokning> HämtaBokningarLogiTyp()
        {

            return new List<MasterBokning>();
        }

        #endregion
    }
}
