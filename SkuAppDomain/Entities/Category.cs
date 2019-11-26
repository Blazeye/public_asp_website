using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;



namespace SkuAppDomain.Entities
{
    [Table("category")]
    public class Category
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int id { get; set; }
        [Required]
        public byte active { get; set; }
        [Required]
        public byte is_dier { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public DateTime? created_at { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public DateTime? updated_at { get; set; }
    }
}
