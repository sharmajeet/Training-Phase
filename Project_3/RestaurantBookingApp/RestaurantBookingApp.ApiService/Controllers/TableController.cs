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
        public async Task<ActionResult<TableModal>> CreateTable(TableModal tableModal) 
        {
            await tableService.CreateTable(tableModal);
            return Ok(new BaseResponseModel { Success = true});
        }

       
    }
}
