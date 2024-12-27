//using Microsoft.AspNetCore.Components;
//using Newtonsoft.Json;
//using RestaurantApp_Model.Entities;
//using RestaurantApp_Model.Models;

//namespace RestaurantBookingApp.Web.Components.Pages.Bookings
//{
//    public partial class IndexBooking
//    {

//        [Inject]
//        public ApiClient ApiClient { get; set; }
//        public List<BookingsModel> BookingModel { get; set; }

//        protected override async Task OnInitializedAsync()
//        {
//            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Bookings");
//            if (res != null && res.Success)
//            {
//                BookingModel = JsonConvert.DeserializeObject<List<BookingsModel>>(res.Data.ToString());
//            }
//            await base.OnInitializedAsync();
//        }
//    }
//}

using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RestaurantApp_Model.Entities;
using RestaurantApp_Model.Models;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;

namespace RestaurantBookingApp.Web.Components.Pages.Bookings
{
    public partial class IndexBooking
    {
        [Inject]
        public HttpClient Http { get; set; }  // Direct HttpClient injection

        [Inject]
        public ApiClient ApiClient { get; set; }

        public List<BookingsModel> BookingModel { get; set; } = new();

        public BookingsModel NewBooking { get; set; } = new()
        {
            TableId = 0,
            CustomerName = string.Empty,
            ContactNumber = string.Empty,
            Date = DateTime.Now,
            Time = TimeSpan.FromHours(12),
            SpecialRequest = string.Empty
        };

        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Bookings");
            if (res != null && res.Success)
            {
                BookingModel = JsonConvert.DeserializeObject<List<BookingsModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }

        public async Task HandleSubmit()
        {
            try
            {
                var bookingToSubmit = new BookingsModel
                {
                    TableId = NewBooking.TableId,
                    CustomerName = NewBooking.CustomerName,
                    ContactNumber = NewBooking.ContactNumber,
                    Date = NewBooking.Date,
                    Time = NewBooking.Time,
                    SpecialRequest = NewBooking.SpecialRequest
                };

                // Option 1: Using direct HttpClient
                var jsonContent = JsonConvert.SerializeObject(bookingToSubmit);
                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await Http.PostAsync("/api/Bookings", stringContent);

                // Option 2: Using HttpClient with System.Net.Http.Json
                // var response = await Http.PostAsJsonAsync("/api/Bookings", bookingToSubmit);

                // Option 3: Using ApiClient if it has SendAsync method
                // var request = new HttpRequestMessage(HttpMethod.Post, "/api/Bookings");
                // request.Content = stringContent;
                // var response = await ApiClient.SendAsync(request);

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);

                if (result != null && result.Success)
                {
                    await OnInitializedAsync();
                    NewBooking = new()
                    {
                        TableId = 0,
                        CustomerName = string.Empty,
                        ContactNumber = string.Empty,
                        Date = DateTime.Now,
                        Time = TimeSpan.FromHours(12),
                        SpecialRequest = string.Empty
                    };
                }
                else
                {
                    Console.WriteLine("Error creating booking: " + result?.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while creating booking: " + ex.Message);
            }
        }
    }
}