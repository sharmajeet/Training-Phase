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
            // Check if the table exists
            var table = await dbContext.Tables
                .SingleOrDefaultAsync(t => t.Id == bookingModel.TableId);

            if (table == null)
            {
                throw new ArgumentException("Table not found");
            }

            // Optionally, check if the table is already booked
          

            // Create a new booking
            var booking = new BookingModel
            {
                TableId = bookingModel.TableId,
                CustomerName = bookingModel.CustomerName,
                CustomerPhone = bookingModel.CustomerPhone,
                BookingDate = bookingModel.BookingDate,
                TimeFrom = bookingModel.TimeFrom,
                TimeTo = bookingModel.TimeTo,
                //Table = BookingModel
            };


            // Add the booking to the dbContext and save changes
            dbContext.Bookings.Add(booking);
            await dbContext.SaveChangesAsync();

            // Return the created booking
            return booking;
        }

        public async Task<BookingModel> CreateBookingWithId(BookingModel bookingModel, int Id)
        {
            // Check if the table exists before creating the booking
            var table = await dbContext.Tables
                .SingleOrDefaultAsync(t => t.Id == Id);

            if (table == null)
            {
                throw new ArgumentException("Table not found");
            }

            // Create a new booking using the provided booking model
            var booking = new BookingModel
            {
                TableId = table.Id,
                CustomerName = bookingModel.CustomerName,
                CustomerPhone = bookingModel.CustomerPhone,
                BookingDate = bookingModel.BookingDate,
                TimeFrom = bookingModel.TimeFrom,
                TimeTo = bookingModel.TimeTo
            };

            // Add the new booking to the context and save changes
            dbContext.Bookings.Add(booking);
            await dbContext.SaveChangesAsync();

            // Return the created booking
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
            //return dbContext.Tables.ToListAsync();
        }

        public async Task UpdateBooking(BookingModel bookingModel)
        {
            dbContext.Entry(bookingModel).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

       
    }
}
