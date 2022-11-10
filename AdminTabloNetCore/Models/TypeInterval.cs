using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class TypeInterval
    {
        [Key]
        public int idInterval { get; set; }
        public string name { get; set; }
        public virtual List<Para> Paras { get; set; } = new List<Para>();
    }
}
