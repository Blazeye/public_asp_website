using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SkuAppDomain.Entities
{
    [Table("comment")]
    public class Comment
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int id { get; set; }
        [Required]
        [Range(1, UInt32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int user_id { get; set; }
        [Required]
        [Range(1, UInt32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int message_id { get; set; }
        [Required]
        public string comment { get; set; }
        [Required]
        public byte marked { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }
    }
}
