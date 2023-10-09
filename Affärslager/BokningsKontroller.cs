﻿using Datalager;
using Entiteter.Personer;
using Entiteter.Tjänster;


namespace Affärslager
{
    public class BokningsKontroller
    {

        UnitOfWork unitOfWork = new UnitOfWork();

        /// <summary>
        /// Metoden kollar igenom alla logier mellan två angivna datum som har status tillgänglig true samt kollar igenom alla bokade logier som är utanför angivet datum f
        /// </summary>
        /// <param name="startdatum"></param>
        /// <param name="slutdatum"></param>
        /// <returns></returns>
        public List<Logi> HämtaTillgängligLogi(DateTime startdatum, DateTime slutdatum)
        {
            //List<Logi> logi = new List<Logi>();


            //foreach (Logi  allLogi in unitOfWork.LogiRepository.Find(a => a.Kök))
            //{
            //    logi.Add(allLogi);
            //}
            ////Hämtar Logi som finns i bokningar och inte matchar angivet datum
            //foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(f => startdatum >= f.SlutDatum || slutdatum <= f.StartDatum))
            //{
            //    foreach (Logi ledigLogi in item.ValdLogi)
            //    {
            //            if (!logi.Contains(ledigLogi))
            //            {
            //               logi.Add(ledigLogi);
            //            }

            //        logi.Add(ledigLogi);
            //    }
            //}

            List<Logi> logi = new List<Logi>();
            foreach (Logi allLogi in unitOfWork.LogiRepository.Find(a => a.Kök))
            {
                logi.Add(allLogi);
            }
            //Hämtar Logi som finns i bokningar och inte matchar angivet datum
            foreach (MasterBokning item in unitOfWork.MasterBokningRepository.Find(f => startdatum <= f.SlutDatum || slutdatum >= f.StartDatum))
            {
                foreach (Logi ledigLogi in item.ValdLogi)
                {
                    if (logi.Contains(ledigLogi))
                    {
                        logi.Remove(ledigLogi);
                    }
                }
            }
            return logi;
        }

        public MasterBokning SkapaMasterbokningPrivatkund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Privatkund privatkund, Användare användare)
        {
            Privatkund privatkund1 = unitOfWork.PrivatkundRepository.FirstOrDefault(pk => pk.Personnummer.Equals(privatkund.Personnummer));
            Användare användare1 = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.AnvändarID.Equals(användare.AnvändarID));
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, privatkund1, användare1);
            unitOfWork.MasterBokningRepository.Add(masterBokning);
            unitOfWork.Complete();
            return masterBokning;
        }

        public MasterBokning SkapaMasterbokningFöretagskund(bool avbeställningsskydd, DateTime startDatum, DateTime slutDatum, IList<Logi> valdLogi, Företagskund företagskund, Användare användare)
        {
            Företagskund företagskund1 = unitOfWork.FöretagskundRepository.FirstOrDefault(fk => fk.OrgNr.Equals(företagskund.OrgNr));
            Användare användare1 = unitOfWork.AnvändareRepository.FirstOrDefault(pk => pk.AnvändarID.Equals(användare.AnvändarID));
            MasterBokning masterBokning = new MasterBokning(avbeställningsskydd, startDatum, slutDatum, valdLogi, företagskund1, användare1);
            unitOfWork.MasterBokningRepository.Add(masterBokning);
            unitOfWork.Complete();
            return masterBokning;
        }




    }
}
