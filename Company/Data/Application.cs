using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CampId { get; set; }
        public Camp Camp { get; set; }
        public int CampersNumber { get; set; }
        public int ChildNumber { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Status { get; set; }

    }
}
