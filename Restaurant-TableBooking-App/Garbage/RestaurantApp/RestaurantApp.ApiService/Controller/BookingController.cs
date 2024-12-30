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

        //[HttpPost]
        //public async Task<ActionResult<BookingModel>> CreateBooking(BookingModel bookingModel)
        //{
        //    await bookingService.CreateBooking(bookingModel);
        //    return Ok(new BaseResponseModel { succees = true });
        //}
        [HttpPost]
        public async Task<ActionResult<BookingModel>> CreateBooking(BookingModel bookingModel)
        {
            await bookingService.CreateBooking(bookingModel);
            return Ok(new BaseResponseModel { succees = true });
        }

        //for put request first we fetch particular Data from Id
        [HttpGet("{Id}")]
        public async Task<ActionResult<BaseResponseModel>> GetBooking(int Id)
        {
            var bookingModel = await bookingService.GetBooking(Id);
            if (bookingModel == null)
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Not Found" });
            }
            return Ok(new BaseResponseModel { succees = true, Data = bookingModel });
        }

        //put request
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateBooking(int Id, BookingModel bookingModel)
        {
            if (Id != bookingModel.Id || !await bookingService.BookingModelExist(Id))
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Bad Request!" });
            }
            await bookingService.UpdateBooking(bookingModel);
            return Ok(new BaseResponseModel { succees = true });
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (!await bookingService.BookingModelExist(id))
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Not Found" });
            }
            await bookingService.DeleteBooking(id);
            return Ok(new BaseResponseModel { succees = true });
        }

    }

    //public class TableController(ITableServices tableService) : ControllerBase
    //{
    //    [HttpGet]
    //    public async Task<ActionResult<BaseResponseModel>> GetTables()
    //    {
    //        var tables = await tableService.GetTables();
    //        return Ok(new BaseResponseModel { succees = true, Data = tables });
    //    }
    //}
 }
