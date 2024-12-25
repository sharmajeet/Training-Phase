namespace RestaurantManagementSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public Table Table { get; set; }
    }
}
