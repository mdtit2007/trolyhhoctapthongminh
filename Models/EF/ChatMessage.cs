using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ungdunghocthongminh.Models.EF
{
    [Table("tb_ChatMessage")]
    public class ChatMessage
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string FilePath { get; set; }
        public DateTime Timestamp { get; set; }
    }
}