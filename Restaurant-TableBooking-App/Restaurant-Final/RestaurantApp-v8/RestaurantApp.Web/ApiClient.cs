using Newtonsoft.Json;

namespace RestaurantApp.Web;

public class ApiClient(HttpClient httpClient)
{

    //For Get 
    public Task<T> GetFromJsonAsync<T>(string path)
    {
        return httpClient.GetFromJsonAsync<T>(path);
    }

    
    //For Post

    public async Task<T1> PostAsync<T1, T2>(string path, T2 postModel)
    {
        var res = await httpClient.PostAsJsonAsync(path, postModel);
        if (res != null && res.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
        }
        return default;
    }

    //function for update - put request
    public async Task<T1> PutAsync<T1, T2>(string path, T2 postModel)
    {
        var res = await httpClient.PutAsJsonAsync(path, postModel);
        if (res != null && res.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
        }
        return default;
    }

    //Delete function
    public async Task<T> DeleteAsync<T>(string path)
    {
        return await httpClient.DeleteFromJsonAsync<T>(path);
    }

}