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

        Task<BookingModel> CreateBookingWithId(BookingModel bookingModel, int Id);



    }
    public class BookingRepository(AppDbContext dbContext) : IBookingRepository
    {
        public Task<bool> BookingModelExist(int Id)
        {
            return dbContext.Bookings.AnyAsync(e => e.TableId == Id);
        }

        //public async Task<BookingModel> CreateBooking(BookingModel bookingModel)
        //{
        //    dbContext.Bookings.Add(bookingModel);
        //    await dbContext.SaveChangesAsync();
        //    return bookingModel;
        //}
        public async Task<BookingModel> CreateBooking(BookingModel bookingModel)
        {
            // Validate required fields
            if (string.IsNullOrEmpty(bookingModel.CustomerName) ||
                string.IsNullOrEmpty(bookingModel.CustomerPhone) ||
                string.IsNullOrEmpty(bookingModel.TimeFrom) ||
                string.IsNullOrEmpty(bookingModel.TimeTo))
            {
                throw new ArgumentException("Required fields are missing");
            }

            // Check if the table exists
            var table = await dbContext.Tables
                .SingleOrDefaultAsync(t => t.Id == bookingModel.TableId);

            if (table == null)
            {
                throw new ArgumentException("Table not found");
            }

            // Check for booking conflicts
            var existingBookings = await dbContext.Bookings
                .Where(b => b.TableId == bookingModel.TableId && 
                           b.BookingDate.Date == bookingModel.BookingDate.Date)
                .ToListAsync();

            var newStart = TimeSpan.Parse(bookingModel.TimeFrom);
            var newEnd = TimeSpan.Parse(bookingModel.TimeTo);

            bool hasConflict = existingBookings.Any(existing =>
            {
                var existingStart = TimeSpan.Parse(existing.TimeFrom);
                var existingEnd = TimeSpan.Parse(existing.TimeTo);
                return (newStart < existingEnd && newEnd > existingStart);
            });

            if (hasConflict)
            {
                //return new InvalidOperationException("This time slot conflicts with an existing booking");
                throw new InvalidOperationException("This time slot conflicts with an existing booking");


            }

            // Create the booking
            dbContext.Bookings.Add(bookingModel);
            await dbContext.SaveChangesAsync();
            return bookingModel;
        }

        public async Task<BookingModel> CreateBookingWithId(BookingModel bookingModel, int Id)
        {
            var table = await dbContext.Tables
                .SingleOrDefaultAsync(t => t.Id == Id);

            if (table == null)
            {
                throw new ArgumentException("Table not found");
            }
            var booking = new BookingModel
            {
                TableId = table.Id,
                CustomerName = bookingModel.CustomerName,
                CustomerPhone = bookingModel.CustomerPhone,
                BookingDate = bookingModel.BookingDate,
                TimeFrom = bookingModel.TimeFrom,
                TimeTo = bookingModel.TimeTo
            };
            dbContext.Bookings.Add(booking);
            await dbContext.SaveChangesAsync();

            return booking;
        }



        public async Task DeleteBooking(int Id)
        {
            var booking = dbContext.Bookings.FirstOrDefault(t => t.TableId == Id);
            dbContext.Bookings.Remove(booking);
            await dbContext.SaveChangesAsync();
        }

        public Task<BookingModel> GetBooking(int Id)
        {
            return  dbContext.Bookings.FirstOrDefaultAsync(n => n.TableId == Id);
        }

        public Task<List<BookingModel>> GetBookings()
        {
            return dbContext.Bookings.ToListAsync();
        }

        public async Task UpdateBooking(BookingModel bookingModel)
        {
            dbContext.Entry(bookingModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

       
    }
}
