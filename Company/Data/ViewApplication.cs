using System;

namespace Company.Data
{
    public class ViewApplication
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PositionTitle { get; set; }
        public string DepartmentTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CampTitle { get; set; }
        public int CampersNumber { get; set; }
        public int ChildNumber { get; set; }
        public string CategoryTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}