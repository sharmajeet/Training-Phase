using System.Net.Http;
using System.Text.Json;
using System.Text;
using RestaurantManagementSystemUI.Components.Model;

public class ReservationService
{
    private readonly HttpClient _httpClient;

    public ReservationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Corrected method signature to accept a Reservation object
    public async Task CreateReservationAsync(Reservation reservation)
    {
        // Serialize the Reservation object to JSON
        var content = new StringContent(JsonSerializer.Serialize(reservation), Encoding.UTF8, "application/json");

        // Send a POST request to the API
        var response = await _httpClient.PostAsync("api/reservations", content);

        // Ensure the response indicates success
        response.EnsureSuccessStatusCode();
    }
}