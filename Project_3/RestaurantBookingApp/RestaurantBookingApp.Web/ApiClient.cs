using System.Net.Http.Json;

namespace RestaurantBookingApp.Web;

public class ApiClient(HttpClient httpClient)
{
    internal static async Task GetFromJsonAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetFromJsonAsync<T>(string path)
    {
        return httpClient.GetFromJsonAsync<T>(path);
    }
}
