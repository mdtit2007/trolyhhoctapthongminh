using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ungdunghocthongminh.Models.EF
{
    public class Exam:CommonAbstract
    {
      
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Level { get; set; }
        public int SubjectId { get; set; }
        public bool IsActive { get; set; }
        public int DocumentCategoryId { get; set; }
        
        public virtual DocumentCategory DocumentCategory { get; set; }

    }
}