using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class Utrustning
    {
        public string UtrustningsId { get; set; }
        public bool Tillgänglig { get; set; }
        public string Benämning { get; set; }

        [ForeignKey("UtrustningsTyp")]
        public string? Typ { get; set; }
        public virtual UtrustningsTyp UtrustningsTyp { get; set; }

        public virtual IList<MasterBokning> MasterBokning { get; set; } = new List<MasterBokning>();

        public Utrustning()
        {

        }

        public Utrustning(string utrustningsId, bool tillgänglig, string benämning, string? typ)
        {
            UtrustningsId = utrustningsId;
            Tillgänglig = tillgänglig;
            Benämning = benämning;
            Typ = typ;
        }
    }
}
