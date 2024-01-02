using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class DayPartHeader
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DayPartHeaderId { get; set; }
        public string Header { get; set; }
        public DateTime beginTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
