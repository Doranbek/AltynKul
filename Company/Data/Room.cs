using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Номер")]
        public int RoomNumber { get; set; }
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        [Display(Name = "Количество мест")]
        public int Amount { get; set; }
        [Display(Name = "Описание")]
        public string Specification { get; set; }

    }
}
