using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkuAppDomain.Entities
{
    [Table("message")]
    public class Message
    {
        [Required]
        public DateTime updated_at { get; set; }
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }
        [Required]
        [Range(0, UInt32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int user_id { get; set; }
        [Required]
        [Range(0, UInt32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int visible_for_role_id { get; set; }
        [Required]
        [Range(0, UInt32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int category_id { get; set; }
        public int? subject_id { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public byte followup { get; set; }
        [Required]
        public byte marked { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        public int followup_user_id { get; set; }
        public DateTime? followup_date { get; set; }
    }
}
