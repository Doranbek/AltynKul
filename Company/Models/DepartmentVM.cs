using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class DepartmentVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Название отдела не указан")]
        [Display(Name = "Отдел")]
        public string Title { get; set; }

        [Display(Name = "Описание отдела")]
        public string Specification { get; set; }
    }
}
