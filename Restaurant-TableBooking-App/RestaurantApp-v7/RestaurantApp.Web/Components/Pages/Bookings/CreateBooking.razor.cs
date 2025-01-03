using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;
using static RestaurantApp.Web.Components.Pages.Tables.IndexTables;

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
        public List<TableModel> TableModels { get; set; } = new List<TableModel>();

        

        protected override async Task OnInitializedAsync()
        {

            Model.BookingDate = DateTime.Now.Date;
            await LoadTable();
        }
        //public async Task Submit()
        //{
        //    var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>("/api/Booking", Model);
        //    if (res != null && res.succees)
        //    {
        //        ToastService.ShowSuccess("Booking Created Successfully.");
        //        NavigationManager.NavigateTo("/booking");
        //    }
        //}

        public async Task Submit()
        {
            // Check if all fields are filled
            switch (true)
            {

                case bool _ when string.IsNullOrEmpty(Model.CustomerName):
                    ToastService.ShowError("Customer Name is required.");
                    return;
                case bool _ when string.IsNullOrEmpty(Model.CustomerPhone):
                    ToastService.ShowError("Contact Number is required.");
                    return;
                case bool _ when Model.BookingDate == null:
                    ToastService.ShowError("Date is required.");
                    return;
                case bool _ when string.IsNullOrEmpty(Model.TimeFrom):
                    ToastService.ShowError("Time From is required.");
                    return;
                case bool _ when string.IsNullOrEmpty(Model.TimeTo):
                    ToastService.ShowError("Time To is required.");
                    return;
            }

            // API Call
            var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>("/api/Booking", Model);
            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Booking Created Successfully.");
                NavigationManager.NavigateTo("/booking");
            }
        }

        protected async Task LoadTable()
        {
            try
            {
                // Call the API to fetch the table data
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Table");

                if (res != null && res.succees)
                {
                    // Deserialize the response data to TableResponseModel
                    var tableResponse = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());

                    if (tableResponse != null)
                    {
                        TableModels = tableResponse.Tables;  // Populate TableModels with the list of tables
                        Console.WriteLine("TableData: ", TableModels);
                    }
                    else
                    {
                        Console.WriteLine("Error: Failed to deserialize table data.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: API response is null or unsuccessful.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An exception occurred while loading tables.");
                Console.WriteLine(ex.Message);  // Log the exception message for debugging
            }

            // Trigger a re-render of the component after the data is loaded
            StateHasChanged();
        }
    }
}