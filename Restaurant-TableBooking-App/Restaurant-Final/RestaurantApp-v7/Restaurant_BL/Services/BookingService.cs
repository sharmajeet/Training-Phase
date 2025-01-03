using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_BL.Repositories;
using Restaurant_Models.Entities;

namespace Restaurant_BL.Services
{
    public interface IBookingService
    {
        Task<List<BookingModel>> GetBookings();
        Task<BookingModel> CreateBooking(BookingModel bookingModel);  // Changed return type
        Task<BookingModel> GetBooking(int Id);
        Task<bool> BookingModelExist(int Id);
        Task UpdateBooking(BookingModel bookingModel);
        Task<BookingModel> CreateBookingWithId(BookingModel bookingModel, int Id);
        Task DeleteBooking(int Id);
    }

    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<bool> BookingModelExist(int Id)
        {
            return _bookingRepository.BookingModelExist(Id);
        }

        public async Task<BookingModel> CreateBooking(BookingModel bookingModel)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(bookingModel.CustomerName) ||
                    string.IsNullOrEmpty(bookingModel.CustomerPhone) ||
                    string.IsNullOrEmpty(bookingModel.TimeFrom) ||
                    string.IsNullOrEmpty(bookingModel.TimeTo))
                {
                    return null;
                }

                // Check for time conflicts
                var existingBookings = await _bookingRepository.GetBookings();
                var conflicts = existingBookings.Where(b => 
                    b.TableId == bookingModel.TableId && 
                    b.BookingDate.Date == bookingModel.BookingDate.Date);

                foreach (var booking in conflicts)
                {
                    var existingStart = TimeSpan.Parse(booking.TimeFrom);
                    var existingEnd = TimeSpan.Parse(booking.TimeTo);
                    var newStart = TimeSpan.Parse(bookingModel.TimeFrom);
                    var newEnd = TimeSpan.Parse(bookingModel.TimeTo);

                    if (newStart < existingEnd && newEnd > existingStart)
                    {
                        return null;
                        // Time conflict found
                    }
                }

                // Create booking if no conflicts
                return await _bookingRepository.CreateBooking(bookingModel);
            }
            catch
            {
                return null;
            }
        }

        public async Task<BookingModel> CreateBookingWithId(BookingModel bookingModel, int Id)
        {
            return await _bookingRepository.CreateBookingWithId(bookingModel, Id);
        }

        public Task DeleteBooking(int Id)
        {
            return _bookingRepository.DeleteBooking(Id);
        }

        public Task<BookingModel> GetBooking(int Id)
        {
            return _bookingRepository.GetBooking(Id);
        }

        public Task<List<BookingModel>> GetBookings()
        {
            return _bookingRepository.GetBookings();
        }

        public Task UpdateBooking(BookingModel bookingModel)
        {
            return _bookingRepository.UpdateBooking(bookingModel);
        }
    }
}