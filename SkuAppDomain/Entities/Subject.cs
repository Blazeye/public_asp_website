using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SkuAppDomain.Entities
{
    [Table("subject")]
    public class Subject
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }
        [Required]
        public int category_id { get; set; }
        [Required]
        public byte active { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }

    }
}
