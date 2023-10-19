using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class Utrustning
    {
        public string UtrustningsId { get; set; }
        public string Benämning { get; set; }
        public bool Status { get; set; } = true;

        [ForeignKey("UtrustningsTyp")]
        public string? Typ { get; set; }
        public virtual UtrustningsTyp UtrustningsTyp { get; set; }



        public Utrustning()
        {

        }

        public Utrustning(string utrustningsId, string benämning, string? typ, bool status)
        {
            UtrustningsId = utrustningsId;
            Benämning = benämning;
            Typ = typ;
            Status = status;
        }

        public bool StatusBokad()
        {
            return Status = false;
        }
        public bool StatusTillgänglig()
        {
            return Status = true;
        }
    }
}
