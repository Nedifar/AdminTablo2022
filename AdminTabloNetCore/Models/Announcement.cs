using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class Announcement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAnnouncement { get; set; }
        public string Header { get; set; }
        public string Name { get; set; }
        public DateTime dateAdded { get; set; }
        public DateTime? dateClosed { get; set; }
        public string Priority { get; set; }
        public bool isActive { get; set; }
        public string status { get; set; }

        public bool running
        {
            get
            {
                if(!dateClosed.HasValue)
                {
                    if (DateTime.Now > dateAdded)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (DateTime.Now > dateAdded && DateTime.Now < dateClosed.Value)
                        return true;
                    else
                        return false;
                }
            }
        }
        public string getPriority
        {
            get
            {
                if (Priority == "1")
                    return "Важное";
                else
                    return "Обычное";
            }
        }
        public string date
        {
            get
            {
                if (dateClosed == null)
                { return "Бессрочно"; }
                else
                    return dateClosed.Value.ToString("dd.MM.yyyy HH.mm");
            }
        }
    }
}
