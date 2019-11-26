using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SkuAppDomain.Entities
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }
        [Required]
        [MaxLength(255)]
        public string role { get; set; }
        [Required]
        [MaxLength(255)]
        public string description { get; set; }
    }
}
