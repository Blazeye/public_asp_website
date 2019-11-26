using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkuAppDomain.Entities
{
    [Table("colors")]
    public class Color
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(20)]
        public string color { get; set; }
    }
}
