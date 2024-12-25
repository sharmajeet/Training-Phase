using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;

[ApiController]
[Route("api/[controller]")]
public class TablesController : ControllerBase
{
    private readonly RestaurantDbContext _context;

    public TablesController(RestaurantDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllTables()
    {
        var tables = _context.Tables.ToList();
        return Ok(tables);
    }

    [HttpPost]
    public IActionResult AddTable(Table table)
    {
        _context.Tables.Add(table);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAllTables), new { id = table.Id }, table);
    }

    [HttpGet("filter")]
    public IActionResult FilterTables(int? seats, DateTime? startDate, DateTime? endDate)
    {
        var query = _context.Tables.AsQueryable();

        if (seats.HasValue)
            query = query.Where(t => t.NumberOfSeats == seats.Value);

        if (startDate.HasValue && endDate.HasValue)
            query = query.Where(t =>
                !_context.Reservations.Any(r =>
                    r.TableId == t.Id &&
                    r.ReservationTime >= startDate.Value &&
                    r.ReservationTime <= endDate.Value));

        return Ok(query.ToList());
    }
}
