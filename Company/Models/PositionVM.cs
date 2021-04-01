﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class PositionVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Должность")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Specification { get; set; }
    }
}
