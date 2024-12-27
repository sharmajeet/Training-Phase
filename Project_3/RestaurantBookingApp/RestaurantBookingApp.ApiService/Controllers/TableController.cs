using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaaurantApp_BL.Services;
using RestaurantApp_Model.Entities;
using RestaurantApp_Model.Models;

namespace RestaurantBookingApp.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController(ITableService tableService) : ControllerBase
    {
        [HttpGet]   
        public async Task<ActionResult<BaseResponseModel>> GetTables()
        {
            var Tables = await tableService.GetTables();
            return Ok(new BaseResponseModel { Success = true , Data = Tables }); 
        }

        // POST: api/Table
        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] TableModal table)
        {
            if (table == null)
            {
                return BadRequest("Table data is null.");
            }

            var newTable = await tableService.AddTable(table);
            return CreatedAtAction(nameof(CreateTable), new { id = newTable.Id }, newTable);
        }

        // PUT: api/Table/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(int id, [FromBody] TableModal table)
        {
            if (table == null || table.Id != id)
            {
                return BadRequest("Table data is invalid.");
            }

            var updatedTable = await tableService.UpdateTable(table);
            if (updatedTable == null)
            {
                return NotFound("Table not found.");
            }

            return Ok(updatedTable);
        }

        // DELETE: api/Table/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var result = await tableService.DeleteTable(id);
            if (!result)
            {
                return NotFound("Table not found.");
            }

            return NoContent();  // Returns a 204 status code with no content
        }
    }
}
