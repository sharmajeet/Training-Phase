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

      
        
        [HttpPost("Create")]
        public async Task<ActionResult<BaseResponseModel>> CreateBooking([FromBody] BookingModel bookingModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new BaseResponseModel
                    {
                       
                        succees = false,
                        ErrorMessage = "Invalid booking data"
                    });
                }

                var result = await bookingService.CreateBooking(bookingModel);
                return Ok(new BaseResponseModel 
                { 
                    succees = true, 
                    Data = result 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponseModel 
                {
                    isDuplicate = true,
                    succees = false, 
                    ErrorMessage = ex.Message 
                });
            }
        }

        
        [HttpPost("{Id}")]

        public async Task<ActionResult<BookingModel>> CreateBookingWithId(BookingModel bookingModel, int Id)
        {
            await bookingService.CreateBookingWithId(bookingModel, Id);
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
            if (Id != bookingModel.TableId|| !await bookingService.BookingModelExist(Id))
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
