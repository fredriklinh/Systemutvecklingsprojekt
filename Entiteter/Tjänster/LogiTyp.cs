using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entiteter.Tjänster
{
    public class LogiTyp
    {

        public string LogiTypId { get; set; }

        public virtual IList<Logi> Logier { get; set; }


        public LogiTyp()
        {

        }




    }
}
