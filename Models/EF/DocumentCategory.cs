using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ungdunghocthongminh.Models.EF
{
    [Table("tb_DocumentCategory")]
    public class DocumentCategory:CommonAbstract
    {
        public DocumentCategory()
        { 
            this.Documents = new HashSet<Document>();
            this.Exams = new HashSet<Exam>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Exam> Exams { get; set; }
       
    }
}