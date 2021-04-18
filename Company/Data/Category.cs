using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Тип номера")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Specification { get; set; }

    }
}
