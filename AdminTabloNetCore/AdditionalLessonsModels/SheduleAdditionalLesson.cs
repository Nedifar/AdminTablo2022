using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.AdditionalLessonsModels
{
    public class SheduleAdditionalLesson
    {
        [Key]
        public int idSheduleAdditionalLesson { get; set; }

        public string name { get; set; }

        public virtual List<DayWeek> DayWeeks { get; set; } = new List<DayWeek>();

        public virtual List<Time> Times { get; set; } = new List<Time>();

    }
}
