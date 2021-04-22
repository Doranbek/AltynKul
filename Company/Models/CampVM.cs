using System;
using System.ComponentModel.DataAnnotations;


namespace Company.Models
{
       public class CampVM
       {
            [Key]
            public int Id { get; set; }
        
            [Display(Name = "Поток")]
            [Required(ErrorMessage = "Названия потока не указан")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Дата начала потока не указан")]
            [Display(Name = "Дата начала потока")]        
            [DataType(DataType.Date)]        
            public DateTime StartDate { get; set; }
        
            [Display(Name = "Дата конца потока")]        
            [DataType(DataType.Date)]
            [Required(ErrorMessage = "Дата конца потока не указан")]
            public DateTime EndDate { get; set; }

            [Display(Name = "Описание")]
            public string Specification { get; set; }

       }
}
