using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystemUI.Components.Model
{
    public class Reservation
    {
        [Required(ErrorMessage = "Table is required.")]
        public int TableId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        public TimeSpan Time { get; set; }
    }
}