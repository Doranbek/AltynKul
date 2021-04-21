using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class CampCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CampId { get; set; }
        public Camp Camp { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
