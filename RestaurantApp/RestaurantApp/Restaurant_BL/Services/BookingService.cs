using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_BL.Repositories;
using Restaurant_Models.Entities;

namespace Restaurant_BL.Services
{
    public interface IBookingService
    {
        Task<List<BookingModel>> GetBookings();
        Task<BookingModel>CreateBooking(BookingModel bookingModel);

    }
    public class BookingService(IBookingRepository bookingRepository) : IBookingService
    {
        public Task<BookingModel> CreateBooking(BookingModel bookingModel)
        {
            return bookingRepository.CreateBooking(bookingModel);
        }

        public Task<List<BookingModel>> GetBookings()
        {
            return bookingRepository.GetBookings();
        }
    }
}
