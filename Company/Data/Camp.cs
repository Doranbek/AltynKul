using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Camp
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название потока")]
        public string Title { get; set; }

        [Display(Name = "Дата начала потока")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата конца потока")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Описание")]
        public string Specification { get; set; }
    }
}
