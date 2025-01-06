using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;
using static RestaurantApp.Web.Components.Pages.Tables.IndexTables;

namespace RestaurantApp.Web.Components.Pages.Bookings
{
    public partial class UpdateBooking : ComponentBase
    {
        // Parameters and properties
        [Parameter]
        public int Id { get; set; }
        public BookingModel Model { get; set; } = new BookingModel { CustomerName = string.Empty };
        public List<TableModel> TableModels { get; set; } = new List<TableModel>();

        // Injected services
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        IToastService ToastService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        // OnInitializedAsync - Load booking details and tables
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadTable();
            await LoadBookingDetails();
        }

        // Submit method for updating the booking
        public async Task Submit()
        {
            var res = await ApiClient.PutAsync<BaseResponseModel, BookingModel>($"/api/Booking/{Id}", Model);

            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Booking Updated Successfully.");
                NavigationManager.NavigateTo("/booking");
            }
        }

        // Load available tables
        protected async Task LoadTable()
        {
            try
            {
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Table");
                if (res != null && res.succees)
                {
                    var tableResponse = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());
                    if (tableResponse != null)
                    {
                        TableModels = tableResponse.Tables;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An exception occurred while loading tables.");
                Console.WriteLine(ex.Message);
            }
        }

        // Load booking details based on Id
        protected async Task LoadBookingDetails()
        {
            try
            {
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Booking/{Id}");
                if (res != null && res.succees)
                {
                    Model = JsonConvert.DeserializeObject<BookingModel>(res.Data.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An exception occurred while loading booking details.");
                Console.WriteLine(ex.Message);
            }
        }

        // Cancel the update and navigate back
        public async Task cancelClick()
        {
            NavigationManager.NavigateTo("/booking");
        }
    }
}
