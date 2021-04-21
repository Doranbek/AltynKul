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
        [Required]
        public int RoomNumber { get; set; }
        [Display(Name = "Категория")]
        [Range(1,int.MaxValue, ErrorMessage = "Выберите категорию")]
        public int CategoryId { get; set; }
        [Display(Name = "Количество мест")]
        public int Amount { get; set; }
        [Display(Name = "Описание")]
        public string Specification { get; set; }

    }
}
