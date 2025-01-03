using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Restaurant_Models.Entities
{
    public class BookingModel
    {
        [Key]
        public int BookingId { get; set; }  

        public int TableId { get; set; }  

       
        //public TableModel Table { get; set; }  // Navigation property to access Table details

        [Required]
        public string CustomerName { get; set; } 

        [Required]
        [Phone]
        public string CustomerPhone { get; set; }  

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }  

        [Required]
        [DataType(DataType.Time)]
        public string TimeFrom { get; set; } 

        [Required]
        [DataType(DataType.Time)]
        public string TimeTo { get; set; } 


      
    }
}
