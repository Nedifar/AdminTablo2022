using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class MonthYear
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMonthYear { get; set; }
        public DateTime date { get; set; }
        public virtual List<SupervisorShedule> SupervisorShedules { get; set; } = new List<SupervisorShedule>();
    }
}
