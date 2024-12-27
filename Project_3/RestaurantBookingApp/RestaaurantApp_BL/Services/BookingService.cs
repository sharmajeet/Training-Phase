using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaaurantApp_BL.Repository;
using RestaurantApp_Model.Entities;

namespace RestaaurantApp_BL.Services
{
    public interface IBookingService
    {
        Task<List<BookingsModel>> GetBookings();
        Task<BookingsModel> CreateBooking(BookingsModel newBooking);
        Task<BookingsModel> UpdateBooking(BookingsModel updatedBooking);
        Task<bool> DeleteBooking(int id);
    }
    public class BookingService(IBookingRepository bookingRepository) : IBookingService
    {
        public Task<List<BookingsModel>> GetBookings()
        {
            return bookingRepository.GetBookings();
        }

        // Call the CreateBooking method from the repository
        public Task<BookingsModel> CreateBooking(BookingsModel newBooking)
        {
            return bookingRepository.CreateBooking(newBooking);
        }

        public Task<BookingsModel> UpdateBooking(BookingsModel updatedBooking)
        {
            return bookingRepository.UpdateBooking(updatedBooking);
        }

        public Task<bool> DeleteBooking(int id)
        {
            return bookingRepository.DeleteBooking(id);
        }
    }
}
