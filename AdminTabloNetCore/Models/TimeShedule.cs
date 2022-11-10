using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class TimeShedule
    {
        [Key]
        public int idTimeShedule { get; set; }
        public string Name { get; set; }
        public virtual ObservableCollection<Para> Paras { get; set; } = new ObservableCollection<Para>();
    }
}
