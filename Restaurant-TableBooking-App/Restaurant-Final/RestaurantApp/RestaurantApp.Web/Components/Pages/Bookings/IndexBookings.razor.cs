using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;
using RestaurantApp.Web.Components.BaseComponent;
using static RestaurantApp.Web.Components.Pages.Tables.IndexTables;

namespace RestaurantApp.Web.Components.Pages.Bookings
{
    public partial class IndexBookings
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<BookingModel> BookingModels { get; set; }

        public List<TableModel> TableModels { get; set; }
        public List<TableModel> Tables { get; set; }

        public AppModel Model { get; set; }

        public int DeleteId { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();
            await LoadTable();
            await LoadBooking();

        }
        protected async Task LoadBooking()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Booking");
            if (res != null && res.succees)
            {
                BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
                //TableModels = JsonConvert.DeserializeObject<List<TableModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
        //method for table 
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


        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Booking/{DeleteId}");
            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Booking Deleted Successfully.");
                await LoadBooking();
                Model.Close();
            }
        }
    }
}
    