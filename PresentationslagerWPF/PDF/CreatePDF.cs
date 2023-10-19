using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Entiteter.Personer;
using Entiteter.Tjänster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace PDF
{
    class CreatePDF
    {
        public static void SkapaBokningsbekräftelsePrivat(Privatkund privatkund, MasterBokning masterbokning, double? totalpris, double? totalprisrabatt, IList<Logi> logis)
        {
            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            string labelText =
                $"\nBokningsbekräftelse för din bokning hos SkiCenter\n" +
                $"\nBokningsnummer: {masterbokning.BokningsNr}" +
                $"\nPersonnummer: {privatkund.Personnummer}" +
                $"\nIncheckningsdatum: {masterbokning.StartDatum}" +
                $"\nUtcheckningsdatum: {masterbokning.SlutDatum}" +
                $"\nTotalpris: {totalpris}" +
                $"\nTotalpris inklusive rabatt: {totalprisrabatt}";

            string logier = "\n\n\n\n\n\n\n\n\n\nLogier som valts i bokningen: \n";
            foreach (var objekt in logis)
            {
                logier += objekt.LogiTyp.LogiTypId.ToString() + Environment.NewLine;
            }
            Label label2 = new Label(logier, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label2);

            Label label = new Label(labelText, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);

            document.Draw(Util.GetPath($"PDF/Bokningsbekräftelse/{masterbokning.BokningsNr}.pdf"));
        }

        public static void SkapaBokningsbekräftelseFöretag(Företagskund företagskund, MasterBokning masterbokning, double? totalpris, double? totalprisrabatt, IList<Logi> logis)
        {
            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            string labelText =
                $"\nBokningsbekräftelse för din bokning hos SkiCenter\n" +
                $"\nBokningsnummer: {masterbokning.BokningsNr}" +
                $"\nPersonnummer: {företagskund.OrgNr}" +
                $"\nIncheckningsdatum: {masterbokning.StartDatum}" +
                $"\nUtcheckningsdatum: {masterbokning.SlutDatum}" +
                $"\nTotalpris: {totalpris}" +
                $"\nTotalpris inklusive rabatt: {totalprisrabatt}";

            string logier = "\n\n\n\n\n\n\n\n\n\nLogier som valts i bokningen: \n";
            foreach (var objekt in logis)
            {
                logier += objekt.LogiTyp.LogiTypId.ToString() + Environment.NewLine;
            }
            Label label = new Label(logier, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);

            Label label2 = new Label(labelText, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label2);

            document.Draw(Util.GetPath($"PDF/Bokningsbekräftelse/{masterbokning.BokningsNr}.pdf"));
        }


        //kundnamn, exemplarnummer och hyrtider.
        public static void SkapaKvittoUthyrningPrivat(Privatkund privatkund, IList<Utrustning> bokadUtrustning, DateTime inlämninsTid)
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            DateTime utlämningsTid = DateTime.Now.Date;
            string labelText =
                $"\nKvitto för din uthyrning av utrustning hos SkiCenter\n" +
                $"\nKund: {privatkund.Förnamn} {privatkund.Efternamn}" +
                $"\n\nUthyrningstider: \nFrån:{utlämningsTid}\nTill:{inlämninsTid}";

            string utrustning = "\n\n\n\n\n\n\n\n\n\nUtrustning som hyrts ut: \n";
            foreach (var objekt in bokadUtrustning)
            {
                utrustning += objekt.UtrustningsId.ToString() + Environment.NewLine;
            }

            Label label = new Label(utrustning, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);

            Label label2 = new Label(labelText, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label2);

            //document.Draw(Util.GetPath($"PDF/{privatkund.MailAdress}.pdf"));

            string initialFilePath = Util.GetPath($"PDF/KvittoUtrustning/{privatkund.MailAdress}.pdf");
            string filePath = initialFilePath;
            int count = 1;

            // Kontrollera om filen redan finns
            while (File.Exists(filePath))
            {
                // Om filen redan finns, lägg till en räknare eller en tidsstämpel i filnamnet för att göra det unikt
                filePath = Util.GetPath($"PDF/KvittoUtrustning/{privatkund.MailAdress}_{count}.pdf");
                count++;
            }

            // Skapa och spara PDF-filen med det unika filnamnet
            document.Draw(filePath);
        }

        public static void SkapaKvittoUthyrningFöretag(Företagskund företagskund, IList<Utrustning> bokadUtrustning, DateTime inlämninsTid)
        {
            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            DateTime utlämningsTid = DateTime.Now.Date;
            string labelText =
                $"\nKvitto för din uthyrning av utrustning hos SkiCenter\n" +
                $"\nKund: {företagskund.FöretagsNamn}" +
                $"\nOrganisationsnummer: {företagskund.OrgNr}" +
                $"\n\nUthyrningstider: \nFrån:{utlämningsTid}\nTill:{inlämninsTid}";

            string utrustning = "\n\n\n\n\n\n\n\n\n\nUtrustning som hyrts ut: \n";
            foreach (var objekt in bokadUtrustning)
            {
                utrustning += objekt.UtrustningsId.ToString() + Environment.NewLine;
            }

            Label label = new Label(utrustning, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);

            Label label2 = new Label(labelText, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label2);

            //document.Draw(Util.GetPath($"PDF/{företagskund.FöretagsNamn}.pdf"));
            string originalFileName = $"{företagskund.MailAdress}.pdf";
            string filePath = Util.GetPath($"PDF/KvittoUtrustning/{originalFileName}");

            int count = 1;
            string newFileName = originalFileName;

            while (File.Exists(filePath))
            {
                // Om filen redan finns, lägg till ett efterföljande nummer i filnamnet och försök igen
                newFileName = $"{företagskund.MailAdress}_{count}.pdf";
                filePath = Util.GetPath($"PDF/KvittoUtrustning/{newFileName}");
                count++;
            }
            document.Draw(filePath);
        }






        public static void SkapaKvittoLektionAlla(MasterBokning mB, DateTime LektionsDatum)
        {
            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);
            string LektionsTyp;
            if (mB.PrivatLektioner != null)
            {
                LektionsTyp = $"\nLektionstyp: Privatlektion";
            }
            else
            {
                LektionsTyp = $"\nLektionstyp: Grupplektion";
            }

            DateTime utlämningsTid = DateTime.Now.Date;
            if(mB.Privatkund !=null)
            {
                string labelTexten =
                    $"\nKvitto för din lektionsbokning hos SkiCenter\n" +
                    $"\nKund: {mB.Privatkund.Förnamn}{mB.Privatkund.Efternamn}" +
                    $"\nPersonnummer: {mB.PersonNr}" +
                    $"\nLektionsdatum:{LektionsDatum}{LektionsTyp}";
                Label label2 = new Label(labelTexten, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
                page.Elements.Add(label2);


                string originalFileName = $"{mB.Privatkund.MailAdress}.pdf";
                string filePath = Util.GetPath($"PDF/KvittoLektion/{originalFileName}");

                int count = 1;
                string newFileName = originalFileName;

                while (File.Exists(filePath))
                {
                    // Om filen redan finns, lägg till ett efterföljande nummer i filnamnet och försök igen
                    newFileName = $"{mB.Privatkund.MailAdress}_{count}.pdf";
                    filePath = Util.GetPath($"PDF/KvittoLektion/{newFileName}");
                    count++;
                }
                document.Draw(filePath);
            }

            if (mB.Företagskund != null)
            {
                string labelTexten =
                    $"\nKvitto för din lektionsbokning hos SkiCenter\n" +
                    $"\nKund: {mB.Företagskund.FöretagsNamn}" +
                    $"\nOrganisationsnummer: {mB.OrgaNr}" +
                    $"\nLektionsdatum:{LektionsDatum}{LektionsTyp}";
                Label label2 = new Label(labelTexten, 0, 0, 504, 500, Font.Helvetica, 18, TextAlign.Center);
                page.Elements.Add(label2);


                string originalFileName = $"{mB.Företagskund.MailAdress}.pdf";
                string filePath = Util.GetPath($"PDF/KvittoLektion/{originalFileName}");

                int count = 1;
                string newFileName = originalFileName;

                while (File.Exists(filePath))
                {
                    // Om filen redan finns, lägg till ett efterföljande nummer i filnamnet och försök igen
                    newFileName = $"{mB.Företagskund.MailAdress}_{count}.pdf";
                    filePath = Util.GetPath($"PDF/KvittoLektion/{newFileName}");
                    count++;
                }
                document.Draw(filePath);
            }
        }

    }
}
