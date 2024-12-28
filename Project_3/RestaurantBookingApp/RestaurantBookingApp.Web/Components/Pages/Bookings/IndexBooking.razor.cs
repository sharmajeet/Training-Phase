//using Microsoft.AspNetCore.Components;
//using Newtonsoft.Json;
//using RestaurantApp_Model.Entities;
//using RestaurantApp_Model.Models;
//using System.Text;
//using System.Net.Http;
//using System.Net.Http.Json;

//namespace RestaurantBookingApp.Web.Components.Pages.Bookings
//{
//    public partial class IndexBooking
//    {
//        [Inject]
//        public HttpClient Http { get; set; }  // Direct HttpClient injection

//        [Inject]
//        public ApiClient ApiClient { get; set; }

//        public List<BookingsModel> BookingModel { get; set; } = new();

//        public BookingsModel NewBooking { get; set; } = new()
//        {
//            TableId = 0,
//            CustomerName = string.Empty,
//            ContactNumber = string.Empty,
//            Date = DateTime.Now,
//            Time = TimeSpan.FromHours(12),
//            SpecialRequest = string.Empty
//        };

//        protected override async Task OnInitializedAsync()
//        {
//            //var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Bookings");
//            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("https://localhost:7564/api/Bookings");

//            if (res != null && res.Success)
//            {
//                BookingModel = JsonConvert.DeserializeObject<List<BookingsModel>>(res.Data.ToString());
//            }
//            await base.OnInitializedAsync();
//        }

//        public async Task HandleSubmit()
//        {
//            try
//            {
//                // Create the booking payload
//                var bookingToSubmit = new BookingsModel
//                {
//                    TableId = NewBooking.TableId,
//                    CustomerName = NewBooking.CustomerName,
//                    ContactNumber = NewBooking.ContactNumber,
//                    Date = NewBooking.Date,
//                    Time = NewBooking.Time,
//                    SpecialRequest = NewBooking.SpecialRequest
//                };

//                // Serialize the payload
//                var jsonContent = JsonConvert.SerializeObject(bookingToSubmit);
//                var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
//                Console.WriteLine("Payload: " + jsonContent);
//                Console.WriteLine(JsonConvert.SerializeObject(bookingToSubmit));

//                // Send the POST request
//                var response = await Http.PostAsync("https://localhost:7564/api/Bookings", stringContent);
//                Console.WriteLine(JsonConvert.SerializeObject(bookingToSubmit));


//                // Read and parse the response
//                var responseContent = await response.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<BaseResponseModel>(responseContent);

//                if (result != null && result.Success)
//                {
//                    Console.WriteLine("Booking successfully created!");

//                    // Refresh the bookings list
//                    await OnInitializedAsync();

//                    // Reset the form
//                    NewBooking = new BookingsModel
//                    {
//                        TableId = 0,
//                        CustomerName = string.Empty,
//                        ContactNumber = string.Empty,
//                        Date = DateTime.Now,
//                        Time = TimeSpan.FromHours(12),
//                        SpecialRequest = string.Empty
//                    };
//                }
//                else
//                {
//                    Console.WriteLine("Error creating booking: " + (result?.ErrorMessage ?? "Unknown error"));
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Exception while creating booking: " + ex.Message);
//            }
//        }

//    }
//}