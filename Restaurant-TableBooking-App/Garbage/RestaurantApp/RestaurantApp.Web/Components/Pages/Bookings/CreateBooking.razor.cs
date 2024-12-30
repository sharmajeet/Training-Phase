using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;

namespace RestaurantApp.Web.Components.Pages.Bookings
{
    public partial class CreateBooking
    {

        public BookingModel Model { get; set; } = new BookingModel { CustomerName = string.Empty };
        [Inject]

        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        // This method is called when the component is initialized
        protected override void OnInitialized()
        {
            // Initialize Model.Date to the current date
            Model.Date = DateTime.Now.Date;  // Set the current date
        }
        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>("/api/Booking", Model);
            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Booking Created Successfully.");
                NavigationManager.NavigateTo("/booking");
            }
        }
    }
}

//using Blazored.Toast.Services;
//using Microsoft.AspNetCore.Components;
//using Restaurant_Models.Entities;
//using Restaurant_Models.Models;

//namespace RestaurantApp.Web.Components.Pages.Bookings
//{
//    public partial class CreateBooking
//    {

//        public BookingModel Model { get; set; } = new BookingModel { CustomerName = string.Empty };
//        [Inject]

//        private ApiClient ApiClient { get; set; }
//        [Inject]
//        private IToastService ToastService { get; set; }
//        [Inject]
//        private NavigationManager NavigationManager { get; set; }

//        // This method is called when the component is initialized
//        protected override void OnInitialized()
//        {
//            // Initialize Model.Date to the current date
//            Model.Date = DateTime.Now.Date;  // Set the current date
//        }
//        public async Task Submit()
//        {
//            var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>("/api/Booking", Model);
//            if (res != null && res.succees)
//            {
//                ToastService.ShowSuccess("Booking Created Successfully.");
//                NavigationManager.NavigateTo("/booking");
//            }
//        }
//    }
//}