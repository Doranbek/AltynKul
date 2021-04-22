using Company.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class VoucherVM
    {

        [Display(Name = "Ф.И.О.")]
        [Required(ErrorMessage = "Не указан Ф.И.О")]
        public string FullName { get; set; }

        [Display(Name = "Поток")]
        [Required(ErrorMessage = "Не выбран поток")]
        public int CampId { get; set; }

        [Display(Name = "Номер")]
        [Required(ErrorMessage = "Не выбран номер")]
        public int RoomId { get; set; }        

        [Display(Name = "Цена")]
        public decimal Cost { get; set; }

        [Display(Name = "Бронировать")]
        public bool Reserved { get; set; }

        [Display(Name = "Оплачено")]
        public bool PayStatus { get; set; }

        [NotMapped]        
        public int ApplicationId { get; set; }

        [NotMapped]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Rooms { get; set; }

    }
}
