using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Models.Entities
{
    public class TableModel
    {
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        public required string Name { get; set; }
        public  string TableTag { get; set; }
        public int Capacity { get; set; }
        public bool IsBooked { get; set; }

        //future work
        public ICollection<BookingModel> Bookings { get; set; }  // One-to-many relationship with Bookings
    }
}

