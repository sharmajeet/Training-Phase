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
        Task<BookingModel> CreateBooking(BookingModel bookingModel);

        Task<BookingModel> GetBooking(int Id);

        Task<bool> BookingModelExist(int Id);
        Task UpdateBooking(BookingModel bookingModel);

        Task DeleteBooking(int Id);

        


    }
    public class BookingService(IBookingRepository bookingRepository) : IBookingService
    {
        public Task<bool> BookingModelExist(int Id)
        {
            return bookingRepository.BookingModelExist(Id);
        }

        public Task<BookingModel> CreateBooking(BookingModel bookingModel)
        {
            return bookingRepository.CreateBooking(bookingModel);
        }

        public Task DeleteBooking(int Id)
        {
            return bookingRepository.DeleteBooking(Id);
        }

        public Task<BookingModel> GetBooking(int Id)
        {
            return bookingRepository.GetBooking(Id);
        }

        public Task<List<BookingModel>> GetBookings()
        {
            return bookingRepository.GetBookings();
        }

        public Task UpdateBooking(BookingModel bookingModel)
        {
            return bookingRepository.UpdateBooking(bookingModel);
        }
    }
}
