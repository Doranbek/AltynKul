using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    
    [Table(name: "ViewApplications")]
    public class ViewApplication
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ф.И.О")]
        public string FullName { get; set; }
        [Display(Name = "Должност")]
        public string PositionTitle { get; set; }
        [Display(Name = "Отдел")]
        public string DepartmentTitle { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Заезд")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Выезд")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Поток")]
        public string CampTitle { get; set; }
        [Display(Name = "Взрослые")]
        public int CampersNumber { get; set; }
        [Display(Name = "Дети")]
        public int ChildNumber { get; set; }
        [Display(Name = "Категория")]
        public string CategoryTitle { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата подачи")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Статус заявки")]
        public bool Status { get; set; }

    }
}