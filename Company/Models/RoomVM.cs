using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class RoomVM
    {
        
        [Key]
        public int Id { get; set; }
        [Display(Name = "Номер")]        
        public int RoomNumber { get; set; }
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        [Display(Name = "Количество мест")]
        public int Amount { get; set; }
        [Display(Name = "Описание")]
        public string Specification { get; set; }

        public List<SelectListItem> Category;
    }
}
