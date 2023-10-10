using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class Konferenslokal
    {
        public string KonferensBenämningsId { get; set; }
        public string Storlek { get; set; }

        public int AntalPlatser { get; set; }

        public virtual MasterBokning? Masterbokning { get; set;}

        

    }
}
