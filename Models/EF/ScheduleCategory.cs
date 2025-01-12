using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ungdunghocthongminh.Models.EF
{
    [Table("tb_ScheduleCategory")]
    public class ScheduleCategory
    {
        public ScheduleCategory() 
        {
            this.Schedules = new HashSet<Schedule>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public ICollection<Schedule> Schedules { get; set; }

    }
}