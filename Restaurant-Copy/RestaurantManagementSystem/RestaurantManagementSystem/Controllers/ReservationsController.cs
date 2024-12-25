using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly RestaurantDbContext _context;

    public ReservationsController(RestaurantDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateReservation(Reservation reservation)
    {
        var table = _context.Tables.FirstOrDefault(t => t.Id == reservation.TableId);
        if (table == null) return NotFound("Table not found");

        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return Ok(reservation);
    }

    [HttpGet]
    public IActionResult GetReservations()
    {
        return Ok(_context.Reservations.ToList());
    }
}
