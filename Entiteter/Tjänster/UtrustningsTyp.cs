using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entiteter.Tjänster
{
    public class UtrustningsTyp
    {
        public int ID { get; set; }
        public string Typ { get; set; }
        public virtual IList<Utrustning> Utrustning { get; set; }

        public UtrustningsTyp()
        {

        }
    }
}
