using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NMemory.Services.Contracts;
using Restaurant_BL.Services;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;

namespace RestaurantApp.ApiService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController(IBookingService bookingService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetBookings()
        {
            var booking = await bookingService.GetBookings();
            return Ok(new BaseResponseModel { succees = true, Data = booking });
        }

        [HttpPost]
        public async Task<ActionResult<BookingModel>> CreateBooking(BookingModel bookingModel)
        {
            await bookingService.CreateBooking(bookingModel);
            return Ok(new BaseResponseModel { succees = true });
        }

    }
}
