using Company.Data.Enum;
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
        public string Position { get; set; }
        [Display(Name = "Отдел")]
        public string Department { get; set; }

        [Display(Name = "Поток")]
        public string Camp { get; set; }
        [Display(Name = "Количество отдыхающих")]
        public int CampersNumber { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата подачи")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Статус заявки")]
        public AppStatus Status { get; set; }

    }
}