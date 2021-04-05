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
        public string Title { get; set; }
        public string Specification { get; set; }
        public decimal Camp1 { get; set; }
        public decimal Camp2 { get; set; }
        public decimal Camp3 { get; set; }
        public decimal Camp4 { get; set; }
        public decimal Camp5 { get; set; }
        public decimal Camp6 { get; set; }
        public decimal Camp7 { get; set; }
        public decimal Camp8 { get; set; }
        public decimal Camp9 { get; set; }      

    }
}
