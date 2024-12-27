using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApp_Database.Data;
using RestaurantApp_Model.Entities;

namespace RestaaurantApp_BL.Repository
{
    

    public interface IBookingRepository
    {
        Task<List<BookingsModel>> GetBookings();
        Task<BookingsModel> CreateBooking(BookingsModel newBooking);
        Task<BookingsModel> UpdateBooking(BookingsModel updatedBooking);
        Task<bool> DeleteBooking(int id);

    }
    public class BookingRepository(AppDbContext dbContext) : IBookingRepository
    {

        public Task<List<BookingsModel>> GetBookings()
        {
            return dbContext.Bookings.ToListAsync();
        }


        // Method POST
        public async Task<BookingsModel> CreateBooking(BookingsModel newBooking)
        {
            // Add the new booking to the context
            await dbContext.Bookings.AddAsync(newBooking);

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            return newBooking; // Return the created booking
        }
        //public async Task<BookingsModel> CreateBooking(BookingsModel newBooking)
        //{
        //    // Create a new instance of the booking (copying data from the provided one)
        //    var bookingToCreate = new BookingsModel
        //    {
        //        TableId = newBooking.TableId,
        //        CustomerName = newBooking.CustomerName,
        //        ContactNumber = newBooking.ContactNumber,
        //        Date = newBooking.Date,
        //        Time = newBooking.Time,
        //        SpecialRequest = newBooking.SpecialRequest
        //    };

        //    // Add the new booking to the context
        //    await dbContext.Bookings.AddAsync(bookingToCreate);

        //    // Save changes to the database
        //    await dbContext.SaveChangesAsync();

        //    // Return the created booking (the newly added one)
        //    return bookingToCreate;
        //}


        public async Task<BookingsModel> UpdateBooking(BookingsModel updatedBooking)
        {
            var existingBooking = await dbContext.Bookings.FindAsync(updatedBooking.Id);
            if (existingBooking == null)
            {
                return null; // Booking not found
            }

            existingBooking.TableId = updatedBooking.TableId;
            existingBooking.CustomerName = updatedBooking.CustomerName;
            existingBooking.ContactNumber = updatedBooking.ContactNumber;
            existingBooking.Date = updatedBooking.Date;
            existingBooking.Time = updatedBooking.Time;
            existingBooking.SpecialRequest = updatedBooking.SpecialRequest;

            await dbContext.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<bool> DeleteBooking(int id)   
        {
            var booking = await dbContext.Bookings.FindAsync(id);
            if (booking == null)
            {
                return false; // Booking not found
            }

            dbContext.Bookings.Remove(booking);
            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}
