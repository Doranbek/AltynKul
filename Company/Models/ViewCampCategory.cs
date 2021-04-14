using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    [Table(name: "ViewCampCategories")]
    public class ViewCampCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Поток")]
        public string Camp { get; set; }

        [Display(Name = "Категория номера")]
        public string Category { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
