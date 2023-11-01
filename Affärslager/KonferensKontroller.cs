using Datalager;
using Entiteter.Tjänster;

namespace Affärslager
{
    public class KonferensKontroller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //Ej atktiv för stunden
        public List<Konferenslokal> HämtaTillgängligKonferens(DateTime startdatum, DateTime slutdatum)
        {
            List<Konferenslokal> lokaler = new List<Konferenslokal>();

            foreach (Konferenslokal konferenslokal in unitOfWork.KonferensLokalRepository.GetAll())
            {
                lokaler.Add(konferenslokal);

            }
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(f => (startdatum >= f.StartDatum && slutdatum <= f.SlutDatum) || (startdatum <= f.SlutDatum && startdatum >= f.StartDatum) || (slutdatum >= f.StartDatum && slutdatum <= f.SlutDatum) && (startdatum <= f.StartDatum && slutdatum >= f.SlutDatum)))
            {
                foreach (Konferenslokal ledigKonferens in item.ValdaKonferenser)
                {
                    lokaler.Remove(ledigKonferens);
                }
            }

            return lokaler;
        }
    }
}
