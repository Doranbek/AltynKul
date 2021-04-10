using Company.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class VoucherVM
    {
        //[Key]
        //public int Id { get; set; }
       
        [Display(Name = "Ф.И.О.")]
        [Required(ErrorMessage = "Не указан Ф.И.О")]
        public string FullName { get; set; }       

        [Display(Name = "Выбрать потока")]
        [Required(ErrorMessage = "Поток не выбран")]
        public int CampId { get; set; }

        [Display(Name = "Номер")]
        [Required(ErrorMessage = "Номера не указан")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
        
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Бронировать")]
        public bool Reserved { get; set; }

        [Display(Name = "Оплачено")]
        public bool PayStatus { get; set; }

        [Display(Name = "Заявка")]
        public int ApplicationId { get; set; }

    }
}
