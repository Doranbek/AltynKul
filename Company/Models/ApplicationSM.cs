using Company.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class ApplicationSM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ф.И.О.")]
        [Required(ErrorMessage = "Не указан Ф.И.О")]
        public string FullName { get; set; }

        [Display(Name = "Отдел")]
        [Required(ErrorMessage = "Отдел не выбрано")]
        public int DepartmentId { get; set; }
        
        [ForeignKey("DepartmentId")]
        public Department Departament { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Должность не заполнен")]
        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        [Display(Name = "Дата начало путевки")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Дата окончание путевки")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Выбрать потока")]
        [Required(ErrorMessage = "Поток не выбран")]
        public int CampId { get; set; }
        public Camp Camp { get; set; }
       
        [Display(Name = "Взрос­лые")]
        [Required(ErrorMessage = "Количество взрослых не указан")]
        public int CampersNumber { get; set; }

        [Display(Name = "Дети")]
        public int ChildNumber { get; set; }

        [Display(Name = "Выборать тип номера")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        public IEnumerable<Camp> Camps { get; set; }
        public IEnumerable<Category> Categoryes { get; set; }


       

       

    }
}
