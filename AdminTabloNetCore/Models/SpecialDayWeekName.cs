using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class SpecialDayWeekName
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSpecialDayWeekName { get; set; }
        public int dayWeek { get; set; } 
    }
}
