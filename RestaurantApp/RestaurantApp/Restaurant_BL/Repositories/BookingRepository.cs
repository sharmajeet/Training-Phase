using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant_Database.Data;
using Restaurant_Models.Entities;

namespace Restaurant_BL.Repositories
{
    public interface IBookingRepository
    {
        Task<List<BookingModel>> GetBookings();
        Task<BookingModel> CreateBooking(BookingModel bookingModel);

        
    }
    public class BookingRepository(AppDbContext dbContext) : IBookingRepository
    {
        public async Task<BookingModel> CreateBooking(BookingModel bookingModel)
        {
            dbContext.Bookings.Add(bookingModel);
            await dbContext.SaveChangesAsync();
            return bookingModel;
        }

        public Task<List<BookingModel>> GetBookings()
        {
            return dbContext.Bookings.ToListAsync();
        }
    }
}
