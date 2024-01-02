using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class SupervisorShedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSupervisorShedule { get; set; }
        public string NameSupervisor { get; set; }
        public string position { get; set; }
        public virtual List<MonthYear> MonthYears { get; set; } = new List<MonthYear>();
        public virtual List<DatesSupervisior> DatesSupervisiors { get; set; } = new List<DatesSupervisior>();
        public DatesSupervisior dd
        {
            get
            {
                var model =  DatesSupervisiors.Where(p=>p.date.Year ==DefaultClass.date.Year && p.date.Month ==DefaultClass.date.Month).FirstOrDefault();
                if(model==null)
                {
                    var item = new DatesSupervisior { date = DefaultClass.date };
                    DatesSupervisiors.Add(item);
                    return item;
                }
                return model;
            }
        }
    }
}
