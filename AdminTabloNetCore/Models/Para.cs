using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
  public class Para
  {
    [System.ComponentModel.DataAnnotations.Key]
    public int idPara { get; set; }
    public string Name { get; set; }
    public int numberInterval { get; set; }
    public Guid guid { get; set; } = Guid.NewGuid();
    public DateTime begin { get; set; }
    public DateTime end { get; set; }
    public int numberInList { get; set; }
    [ForeignKey("TypeInterval")]
    public int idTypeInterval { get; set; }
    public virtual TypeInterval TypeInterval { get; set; }
    [ForeignKey("TimeShedule")]
    public int idTimeShedule { get; set; }
    public virtual TimeShedule TimeShedule { get; set; }

    public Para()
    {

    }

    public Para(Para para)
    {
      this.end = para.end;
      this.begin = para.begin;
      this.idTypeInterval = para.idTypeInterval;
      this.idTimeShedule = para.idTimeShedule;
      this.Name = para.Name;
      this.TimeShedule = para.TimeShedule;
      this.TypeInterval = para.TypeInterval;
    }
  }
}
