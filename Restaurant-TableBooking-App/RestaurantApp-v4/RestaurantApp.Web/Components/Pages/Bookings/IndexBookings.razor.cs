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
        protected PaginationModel Pagination { get; set; } = new();
        protected int CurrentPage { get; set; } = 1;
        protected int PageSize { get; set; } = 7;
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
            await LoadTable(CurrentPage);
            await LoadBooking(CurrentPage);

        }
        protected async Task LoadBooking(int page)
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
        protected async Task LoadTable(int page)
        {
            try
            {
                // Update the current page number
                CurrentPage = page;

                // Call the API to fetch the data for the requested page
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Table?page={page}&pageSize={PageSize}");
                Console.WriteLine(JsonConvert.SerializeObject(res.Data));

                if (res != null && res.succees)
                {
                    // Deserialize the response to a structured model
                    var data = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());

                    // Update the table data and pagination info
                    TableModels = data.Tables;
                    Pagination = data.Pagination;
                }
                else
                {
                    ToastService.ShowError("Failed to load tables.");
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError("An error occurred while loading the tables.");
            }

            // Trigger a re-render of the component after data update
            StateHasChanged();
        }


        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Booking/{DeleteId}");
            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Booking Deleted Successfully.");
                await LoadBooking(CurrentPage);
                Model.Close();
            }
        }



        // Model for pagination
        public class PaginationModel
        {
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
        }

        // Model for the response containing table data and pagination info
        public class TableResponseModel
        {
            public List<TableModel> Tables { get; set; }
            public PaginationModel Pagination { get; set; }
        }
    }
}
    