using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaaurantApp_BL.Services;
using RestaurantApp_Model.Entities;
using RestaurantApp_Model.Models;

namespace RestaurantBookingApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookingService bookingService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetBookings()
        {
            var Bookings = await bookingService.GetBookings();
            return Ok(new BaseResponseModel { Success = true, Data = Bookings });
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseModel>> CreateBooking([FromBody] BookingsModel newBooking)
        {
            if (newBooking == null)
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Invalid booking data" });
            }

            try
            {
                // Ensure all required properties are provided
                if (string.IsNullOrWhiteSpace(newBooking.CustomerName) ||
                    string.IsNullOrWhiteSpace(newBooking.ContactNumber) ||
                    newBooking.Date == default ||
                    newBooking.Time == default)
                {
                    return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Missing required booking details" });
                }

                // Use the booking service to insert the new booking
                var createdBooking = await bookingService.CreateBooking(newBooking);

                // Check if the booking was successfully created
                if (createdBooking == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponseModel
                    {
                        Success = false,
                        ErrorMessage = "Failed to create booking due to an internal server error"
                    });
                }

                // Return a successful response with the newly created booking
                return CreatedAtAction(nameof(GetBookings), new { id = createdBooking.Id }, new BaseResponseModel
                {
                    Success = true,
                    Data = createdBooking
                });
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponseModel
                {
                    Success = false,
                    ErrorMessage = $"Unexpected error: {ex.Message}"
                });
            }
        }


        // PUT: api/Bookings/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponseModel>> UpdateBooking(int id, [FromBody] BookingsModel updatedBooking)
        {
            if (updatedBooking == null || updatedBooking.Id != id)
            {
                return BadRequest(new BaseResponseModel { Success = false, ErrorMessage = "Booking data is invalid" });
            }

            var booking = await bookingService.UpdateBooking(updatedBooking);
            if (booking == null)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Booking not found" });
            }

            return Ok(new BaseResponseModel { Success = true, Data = booking });
        }

        // DELETE: api/Bookings/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponseModel>> DeleteBooking(int id)
        {
            var result = await bookingService.DeleteBooking(id);
            if (!result)
            {
                return NotFound(new BaseResponseModel { Success = false, ErrorMessage = "Booking not found" });
            }

            return NoContent();  // Returns a 204 status code with no content
        }
    }
}
