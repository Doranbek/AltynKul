using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }      
        public int CampId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Не выбран номер")]
        public int RoomId { get; set; }
        public Room Room { get; set; }       
        public decimal Cost { get; set; }
        public bool Reserved { get; set; }
        public bool  PayStatus { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        public DateTime? CreatedDate { get; set; }       

    }
}
