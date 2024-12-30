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
        public int Id { get; set; }

        public int TableId { get; set; } // Foreign key to TableModel

        // Navigation property to TableModel
        public TableModel Table { get; set; } = new TableModel { Name = string.Empty };// Corrected reference to TableModel

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //[Required]
        //[DataType(DataType.Time)]

        [Required]
        public string Time { get; set; }

        public string TableType { get; set; }
    }
}
