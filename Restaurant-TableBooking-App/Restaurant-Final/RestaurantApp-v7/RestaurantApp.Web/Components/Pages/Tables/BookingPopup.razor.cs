//using Blazored.Toast.Services;
//using Microsoft.AspNetCore.Components;
//using Restaurant_Models.Entities;
//using Restaurant_Models.Models;
//using static RestaurantApp.Web.Components.Pages.Tables.IndexTables;

//namespace RestaurantApp.Web.Components.Pages.Tables
//{
//    public partial class BookingPopup
//    {
//        [Parameter]
//        public int Id { get; set; }

//        public int BookingId { get; set; }

//        [Inject]
//        private ApiClient ApiClient { get; set; }

//        [Inject]
//        private IToastService ToastService { get; set; }

//        [Inject]
//        private NavigationManager NavigationManager { get; set; }

//        public List<TableModel> tableModels { get; set; } = new List<TableModel>();
//        public BookingModel Model { get; set; } = new BookingModel { CustomerName = string.Empty };

//        // This is where you can load the table data (you can replace this with the appropriate API call to load tables)
//        protected override async Task OnInitializedAsync()
//        {
//            try
//            {
//                // Populate the table list (replace with actual API call)
//                tableModels = await ApiClient.GetFromJsonAsync<List<TableModel>>("/api/tables");
//            }
//            catch (Exception ex)
//            {
//                ToastService.ShowError("Failed to load tables.");
//            }
//        }

//        protected async Task HandleBooking()
//        {
//            try
//            {
//                // Assuming you want to book a table based on BookingId passed via route
//                var tableToBook = tableModels.FirstOrDefault(t => t.Id == BookingId); // Find the table by BookingId

//                if (tableToBook != null)
//                {
//                    // Send the booking data to the server
//                    var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>($"/api/Booking/{BookingId}", Model);

//                    if (res != null && res.succees)
//                    {
//                        ToastService.ShowSuccess("Table booked successfully.");
//                        NavigationManager.NavigateTo("/booking/success"); // Redirect to a success page
//                    }
//                    else
//                    {
//                        ToastService.ShowError("Failed to book the table.");
//                    }
//                }
//                else
//                {
//                    ToastService.ShowError("Table not found.");
//                }
//            }
//            catch (Exception ex)
//            {
//                ToastService.ShowError("An error occurred while booking the table.");
//            }
//        }
//    }
//}
