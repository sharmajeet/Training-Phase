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

        Task<BookingModel> GetBooking(int Id);

        Task<bool> BookingModelExist(int Id);

        Task UpdateBooking(BookingModel bookingModel);

        Task DeleteBooking(int Id);


    }
    public class BookingRepository(AppDbContext dbContext) : IBookingRepository
    {
        public Task<bool> BookingModelExist(int Id)
        {
            return dbContext.Bookings.AnyAsync(e => e.Id == Id);
        }

        public async Task<BookingModel> CreateBooking(BookingModel bookingModel)
        {
            dbContext.Bookings.Add(bookingModel);
            await dbContext.SaveChangesAsync();
            return bookingModel;
        }

        public async Task DeleteBooking(int Id)
        {
            var booking = dbContext.Bookings.FirstOrDefault(t => t.Id == Id);
            dbContext.Bookings.Remove(booking);
            await dbContext.SaveChangesAsync();
        }

        public Task<BookingModel> GetBooking(int Id)
        {
            return dbContext.Bookings.FirstOrDefaultAsync(n => n.Id == Id);
        }

        public Task<List<BookingModel>> GetBookings()
        {
            return dbContext.Bookings.ToListAsync();
            //return dbContext.Tables.ToListAsync();
        }

        //public async Task<List<BookingModel>> GetBookings()
        //{
        //    var bookings = await dbContext.Bookings
        //                                    .Include(b => b.Table)  // Eagerly load the related Table entity
        //                                    .ToListAsync();
        //    Console.WriteLine("Bookings : " , bookings);

        //    return bookings;
        //}

        public async Task UpdateBooking(BookingModel bookingModel)
        {
            dbContext.Entry(bookingModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
