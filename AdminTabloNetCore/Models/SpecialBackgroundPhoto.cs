using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class SpecialBackgroundPhoto
    {
        [Key]
        public int idSpecialBackgroundPhoto { get; set; }

        public DateTime? targetDate { get; set; }

        public string fileName { get; set; }
    }
}
