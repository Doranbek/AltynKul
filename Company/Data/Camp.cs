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
        public string Title { get; set; }
        public DateTime StartdDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Specification { get; set; }
    }
}
