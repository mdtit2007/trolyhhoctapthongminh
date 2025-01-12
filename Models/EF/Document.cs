using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ungdunghocthongminh.Models.EF
{
    [Table("tb_Documents")]
    public class Document:CommonAbstract
    {
     
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Alias { get; set; }
        public string Img { get; set; }
        
        public string FilePath { get; set; }

        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string link { get; set; }
        public bool IsHome { get; set; }
        public bool IsActive { get; set; }
        public int DocumentCategoryId { get; set; }
        public int DocumentSubjectId { get; set; }
        public virtual DocumentCategory DocumentCategory { get; set; }
      
       
    }
}