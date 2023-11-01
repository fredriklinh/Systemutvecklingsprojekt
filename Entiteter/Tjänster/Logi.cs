using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class Logi
    {
        public Logi()
        {

        }

        public Logi(string logiId, int kvadratmeter, int bäddar, bool kök, string typen, LogiTyp? logiTyp)
        {
            LogiId = logiId;
            Kvadratmeter = kvadratmeter;
            Bäddar = bäddar;
            Kök = kök;
            Typen = typen;
            LogiTyp = logiTyp;
        }

        public string LogiId { get; set; }

        public int Kvadratmeter { get; set; }
        public int Bäddar { get; set; }
        public bool Kök { get; set; }

        [ForeignKey("LogiTyp")]
        public string Typen { get; set; }
        public virtual LogiTyp? LogiTyp { get; set; }


        //Ska vara enum istället, tre olika metoder, för att definiera "pågående", tillgänglig och bokad"



    }
}
