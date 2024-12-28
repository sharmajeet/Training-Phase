using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantApp_Model.Entities
{

    public class BookingsModel
    {
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //[Required]
        public TimeSpan Time { get; set; }
        public string SpecialRequest { get; set; }
    }


    //public class BookingsModel
    //{
    //    public int Id { get; set; }
    //    [Required]
    //    public int TableId { get; set; }
    //    public required string CustomerName { get; set; }
    //    public required string ContactNumber { get; set; }
    //    public required DateTime Date { get; set; }
    //    public required TimeSpan Time { get; set; }
    //    public required string SpecialRequest { get; set; }


    //}
}
