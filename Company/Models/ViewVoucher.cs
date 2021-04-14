﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    [Table(name: "ViewVouchers")]
    public class ViewVoucher
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ф.И.О.")]
        public string FullName { get; set; }

        [Display(Name = "Поток")]
        public string Camp { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Цена")]
        public decimal Cost { get; set; }

        [Display(Name = "Статус")]
        public bool Reserved { get; set; }

        [Display(Name = "Статус оплаты")]
        public bool PayStatus { get; set; }

        [NotMapped]
        public int ApplicationId { get; set; }
      
    }
}
