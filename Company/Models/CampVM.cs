using Company.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
       public class CampVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Поток")]
        public string Title { get; set; }
        [Display(Name = "Дата начала потока")]
        [Required(ErrorMessage = "Дата начала потока не указан")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Дата конца потока")]
        [Required(ErrorMessage = "Дата конца потока не указан")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Описание")]
        public string Specification { get; set; }

    }
}
