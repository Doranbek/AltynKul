using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Отделы")]
        public string Title { get; set; }
        [Display(Name = "Описание отдела")]
        public string Specification { get; set; }
    }
}
