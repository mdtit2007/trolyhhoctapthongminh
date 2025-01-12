using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace ungdunghocthongminh.Models.EF
{
    [Table("tb_Category")]
    public class Category:CommonAbstract
    {
        public Category()
        {
            this.DigitalConversions = new HashSet<DigitalConversion>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không để trống")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        //[StringLength(150)]
        //public string TypeCode { get; set; }
        public string link { get; set; }
        public string Description { get; set; }

        [StringLength(150)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoDescription { get; set; }
        [StringLength(150)]
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public ICollection<DigitalConversion> DigitalConversions { get; set; } //1 danh mục có thể chứa nhiều bài viết
    }
}