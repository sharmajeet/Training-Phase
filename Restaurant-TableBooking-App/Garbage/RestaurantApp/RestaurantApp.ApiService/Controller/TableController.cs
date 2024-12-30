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
        //[HttpGet]
        //public async Task<ActionResult<BaseResponseModel>> GetTables()
        //{
        //    var tables = await tableService.GetTables();
        //    return Ok(new BaseResponseModel { succees = true, Data = tables });
        //}

        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetTables(int page = 1, int pageSize = 10)
        {
            try
            {
                // Fetch all tables from the service
                var allTables = await tableService.GetTables();

                // Apply pagination
                var paginatedTables = allTables
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();

                // Create the response with pagination info
                return Ok(new BaseResponseModel
                {
                    succees = true,
                    Data = new
                    {
                        Tables = paginatedTables,
                        Pagination = new
                        {
                            CurrentPage = page,
                            PageSize = pageSize,
                            TotalItems = allTables.Count(),
                            TotalPages = (int)Math.Ceiling(allTables.Count() / (double)pageSize)
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return StatusCode(500, new BaseResponseModel
                {
                    succees = false,
                    ErrorMessage = "An error occurred while fetching the tables."
                });
            }
        }



        [HttpPost]
        public async Task<ActionResult<TableModel>> CreateTable(TableModel tableModel)
        {
            await tableService.CreateTable(tableModel);
            return Ok(new BaseResponseModel { succees = true });
        }

        //[HttpPost]
        //public async Task<ActionResult<TableModel>> CreateTable(TableModel tableModel)
        //{
        //    await tableService.CreateTable(tableModel);
        //    return Ok(new BaseResponseModel { succees = true });
        //}

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
            if (Id != tableModel.Id || !await tableService.TableModelExist(Id))
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Bad Request!" });
            }
            await tableService.UpdateTable(tableModel);
            return Ok(new BaseResponseModel {succees = true });
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(!await tableService.TableModelExist(id))
            {
                return Ok(new BaseResponseModel { succees = false, ErrorMessage = "Not Found" });
            }
            await tableService.DeleteProduct(id);
            return Ok(new BaseResponseModel { succees = true });
        }

    }
}
