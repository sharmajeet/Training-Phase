using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NMemory.Services.Contracts;
using Restaurant_Models.Models;
using Restaurant_BL.Services;
using Restaurant_Models.Entities;

namespace RestaurantApp.ApiService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController(ITableServices tableService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetTables()
        {
            var tables = await tableService.GetTables();
            return Ok(new BaseResponseModel { succees = true, Data = tables });
        }

        [HttpPost]
        public async Task<ActionResult<TableModel>> CreateTable(TableModel tableModel)
        {
            await tableService.CreateTable(tableModel);
            return Ok(new BaseResponseModel { succees = true });
        }

        //for put request first we fetch particular Data from Id
        [HttpGet("{Id}")]
        public async Task<ActionResult<BaseResponseModel>> GetTable(int Id)
        {
            var tableModel = await tableService.GetTables(Id);
            if (tableModel == null)
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Not Found" });
            }
            return Ok(new BaseResponseModel { succees = true , Data = tableModel});
        }

        //put request
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateTable(int Id ,TableModel tableModel )
        {
            if (Id != tableModel.Id || !await tableService.TableModelExistAsync(Id))
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Bad Request!" });
            }
            await tableService.UpdateTable(tableModel);
            return Ok(new BaseResponseModel {succees = true });
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(!await tableService.TableModelExistAsync(id))
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Not Found" });
            }
            await tableService.DeleteProduct(id);
            return Ok(new BaseResponseModel { succees = true });
        }

    }
}
