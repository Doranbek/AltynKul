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

        [Display(Name = "Цена за поток I")]
        public decimal Camp1 { get; set; }
        [Display(Name = "Цена за поток II")]
        public decimal Camp2 { get; set; }
        [Display(Name = "Цена за поток III")]
        public decimal Camp3 { get; set; }
        [Display(Name = "Цена за поток IV")]
        public decimal Camp4 { get; set; }
        [Display(Name = "Цена за поток V")]
        public decimal Camp5 { get; set; }
        [Display(Name = "Цена за поток VI")]
        public decimal Camp6 { get; set; }
        [Display(Name = "Цена за поток VII")]
        public decimal Camp7 { get; set; }
        [Display(Name = "Цена за поток VIII")]
        public decimal Camp8 { get; set; }
        [Display(Name = "Цена за поток IX")]
        public decimal Camp9 { get; set; }

    }
}
