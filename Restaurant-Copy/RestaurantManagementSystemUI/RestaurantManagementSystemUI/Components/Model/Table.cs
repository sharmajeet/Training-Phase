namespace RestaurantManagementSystemUI.Components.Model
{
    public class Table
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int SeatingCapacity { get; set; }

        public int TableId { get; set; }
        public DateTime Date { get; set; } // Ensure this property exists
        public TimeSpan Time { get; set; } // Ensure this property exists
    }

}
