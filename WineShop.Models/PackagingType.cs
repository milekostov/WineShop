using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineShop.Models
{
    public class PackagingType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Packaging Type")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
