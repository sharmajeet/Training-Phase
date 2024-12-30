using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Restaurant_BL.Services;
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

        // List to store tables retrieved from the database
        //public List<TableModel> TableList { get; set; } = new List<TableModel>();

        // Inject the TableService to get table data from the database
        //[Inject]
        //public ITableServices TableService { get; set; }

        protected override async Task OnInitializedAsync()
        {
                Model.Date = DateTime.Now.Date;  // Set the current date
            //try
            //{
            //    // Initialize Model.Date to the current date

            //    // Fetch the list of available tables from the TableService
            //    //TableList = await TableService.GetAvailableTablesAsync();
            //}
            //catch (Exception ex)
            //{
            //    // Handle the error (log it or show an error message to the user)
            //    //ToastService.ShowError("Error fetching tables: " + ex.Message);
            //}

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
