using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;

namespace SkuAppDomain.Entities
{
    [Table("user")]
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter a username")]
        [Display(Description = "Username")]
        [MaxLength(50)]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter a colorID")]
        [Range(1, UInt32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int color { get; set; }
        [Required(ErrorMessage = "Please enter a roleID")]
        [Range(1, UInt32.MaxValue, ErrorMessage = "Please enter a positive number")]
        public int role { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public sbyte active { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        public DateTime last_logout { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [HiddenInput(DisplayValue = false)]
        public DateTime? created_at { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [HiddenInput(DisplayValue = false)]
        public DateTime? updated_at { get; set; }
        [Required]
        [HiddenInput(DisplayValue = false)]
        [MaxLength(255)]
        public string encrypted_password { get; set; }
    }
}
