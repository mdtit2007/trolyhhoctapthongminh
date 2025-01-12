using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ungdunghocthongminh.Models.EF
{
    [Table("tb_Schedule")]
    public class Schedule:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Thu { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string ClassId { get; set; }
        public string Tiet { get; set; }
        public string className { get; set; }
        public string TeacherName { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Reminder { get; set; }
        public int ScheduleCategoryId { get; set; }
        public bool IsHome { get; set; }
        public virtual ScheduleCategory ScheduleCategory { get; set; }
    }
}