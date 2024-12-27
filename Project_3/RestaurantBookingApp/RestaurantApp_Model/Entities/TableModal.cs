using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_Model.Entities
{
    public class TableModal
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsBooked { get; set; }

        //future work
        //public ICollection<BookingsModel> Bookings { get; set; }  // One-to-many relationship with Bookings



    }
}
