using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.LayoutEngine;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading;
using System.Runtime.CompilerServices;

namespace PDF
{
    public class CreatePDF
    {

        public static void Run(Privatkund privatkund, MasterBokning masterbokning, double? totalpris, double? totalprisrabatt, IList<Logi> logis)
        {
            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);
            string labelText =
                $"\nBokningsbekräftelse" +
                $"\nBokningsnummer: {masterbokning.BokningsNr}" +
                $"\nPersonnummer: {privatkund.Personnummer}" +
                $"\nIncheckningsdatum: {masterbokning.StartDatum}" +
                $"\nUtcheckningsdatum: {masterbokning.SlutDatum}" +
                $"\nTotalpris: {totalpris}" +
                $"\nTotalpris inklusive rabatt: {totalprisrabatt}";
            Label label = new Label(labelText, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            //page.Elements.Add(label);

            List<Logi> logier = masterbokning.ValdLogi.ToList();

            foreach (Logi login in logier)
            {
                string typ = login.LogiTyp.LogiTypId.ToString();
                string id = login.LogiId.ToString();
                int hej = 1;
                int jeh = hej++;
                //page.Elements[]
                for (int i = 0; i <= jeh; i++)
                {
                    string labelText2 =
                      $"\nLogi ID: {id} "+
                      $"\nTyp av logi: {typ} ";
                    Label label2 = new Label(labelText2+labelText, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
                    //page.Elements.Add(label2);
                    
                }
                

            }
            //string combinedString = string.Join(",", logis);
            //string test = labelText + combinedString;
            //page.Elements.RelativeTo.HasFlag(PageOrientation.Portrait);
            //page.Elements[1].RelativeTo(page.UnderlyingElements);

            document.Draw(Util.GetPath($"PDF/{masterbokning.BokningsNr}.pdf"));
        }
    }
}
