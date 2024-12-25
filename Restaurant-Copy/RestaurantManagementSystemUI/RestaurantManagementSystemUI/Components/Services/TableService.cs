using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RestaurantManagementSystemUI.Components.Model;

namespace RestaurantManagementSystemUI.Services
{
    public class TableService
    {
        private readonly HttpClient _httpClient;

        public TableService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // This method fetches the list of available tables from the backend API
        public async Task<List<Table>> GetAvailableTablesAsync()
        {
            try
            {
                // Make an HTTP GET request to your backend API endpoint
                var response = await _httpClient.GetFromJsonAsync<List<Table>>("api/tables/available");

                // Return the list of tables from the response
                return response ?? new List<Table>();
            }
            catch (Exception ex)
            {
                // Log or handle the error accordingly
                Console.Error.WriteLine($"Error fetching available tables: {ex.Message}");
                return new List<Table>();  // Return an empty list in case of an error
            }
        }
    }
}



//using System.Net.Http;
//using System.Net.Http.Json;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//public class TableService
//{
//    private readonly HttpClient _httpClient;

//    public TableService(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }

//    public async Task<List<Table>> GetTablesAsync()
//    {
//        return await _httpClient.GetFromJsonAsync<List<Table>>("api/tables");   
//    }

//    public async Task<List<Table>> GetAvailableTablesAsync()
//    {
//        return await _httpClient.GetFromJsonAsync<List<Table>>("api/tables/available");
//    }
//}
