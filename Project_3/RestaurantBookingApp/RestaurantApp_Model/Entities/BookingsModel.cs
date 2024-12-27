using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantApp_Model.Entities
{

    //public class BookingsModel
    //{
    //    public int Id { get; set; }

    //    [Required(ErrorMessage = "Table ID is required.")]
    //    public int TableId { get; set; }

    //    [Required(ErrorMessage = "Customer Name is required.")]
    //    public string CustomerName { get; set; }

    //    [Required(ErrorMessage = "Contact Number is required.")]
    //    public string ContactNumber { get; set; }

    //    [Required(ErrorMessage = "Date is required.")]
    //    public DateTime Date { get; set; }

    //    [Required(ErrorMessage = "Time is required.")]
    //    public TimeSpan Time { get; set; }

    //    public string SpecialRequest { get; set; }
    //}

    public class BookingsModel
    {
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        public required string CustomerName { get; set; }
        public required string ContactNumber { get; set; }
        public required DateTime Date { get; set; }
        public required TimeSpan Time { get; set; }
        public required string SpecialRequest { get; set; }


    }
}
