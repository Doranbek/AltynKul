using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class CampCategoryVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Поток")]
        [Required(ErrorMessage = "Поток не выбран")]
        public int CampId { get; set; }
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Категория не выбрана")]
        public int CategoryId { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Цена не указан")]
        public decimal Price { get; set; }

        public IEnumerable<SelectListItem> Camps { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
