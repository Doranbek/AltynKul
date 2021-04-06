using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber{ get; set; }        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public string Specification { get; set; }

    }
}
