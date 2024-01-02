using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        public string Name { get; set; }

        public string PasHash { get; set; }
    }
}
