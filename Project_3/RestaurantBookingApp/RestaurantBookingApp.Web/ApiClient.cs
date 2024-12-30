using System.Net.Http.Json;
using Newtonsoft.Json;

namespace RestaurantBookingApp.Web;

public class ApiClient(HttpClient httpClient)
{
//For Get Requests..
    
    public Task<T> GetFromJsonAsync<T>(string path)
    {
        return httpClient.GetFromJsonAsync<T>(path);
    }
    internal static async Task GetFromJsonAsync()
    {
        throw new NotImplementedException();
    }


    //For Post Request

    public async Task<T1> PostAsync<T1,T2>(string path, T2 postModel)
    {
        var res = await httpClient.PostAsJsonAsync(path, postModel);
        if(res != null && res.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
        }
        return default;
    }

}
