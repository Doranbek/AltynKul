using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class CategoryVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Тип номера")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Specification { get; set; }
    }
}
