using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class ApplicationSM
    {

        [Display(Name = "Ф.И.О.")]
        [Required(ErrorMessage = "Не указан Ф.И.О")]
        public string FullName { get; set; }

        [Display(Name = "Отдел")]
        [Required(ErrorMessage = "Отдел не выбрано")]
        public int DepartmentId { get; set; }
     
        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Должность не заполнен")]
        public int PositionId { get; set; }

        [Display(Name = "Выбрать потока")]
        [Required(ErrorMessage = "Поток не выбран")]
        public int CampId { get; set; }

        [Display(Name = "Взрос­лые")]
        [Required(ErrorMessage = "Количество взрослых не указан")]
        public int CampersNumber { get; set; }

        [Display(Name = "Выборать тип номера")]
        public int CategoryId { get; set; }
        

        public IEnumerable<SelectListItem> Departments { get; set; }

        public IEnumerable<SelectListItem> Positions { get; set; }

        public IEnumerable<SelectListItem> Camps { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }        

    }
}
