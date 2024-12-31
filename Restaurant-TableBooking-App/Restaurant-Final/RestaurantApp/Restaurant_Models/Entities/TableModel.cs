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
        public int Id { get; set; }  // Primary key (equivalent to Table's Id in SQL)

        [Required]
        public string TableType { get; set; }  // Type of the table (e.g., Window Seat, VIP)

        public string TableTag { get; set; }  // Tag for the table (e.g., Indoor, Outdoor)

        [Required]
        public int Capacity { get; set; }  // Number of seats at the table

        // Future work to handle Bookings
        //public ICollection<BookingModel> Bookings { get; set; }  // One-to-many relationship with Bookings
    }
}

