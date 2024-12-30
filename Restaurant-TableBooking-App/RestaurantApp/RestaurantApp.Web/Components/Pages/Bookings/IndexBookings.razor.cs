using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;
using RestaurantApp.Web.Components.BaseComponent;

namespace RestaurantApp.Web.Components.Pages.Bookings
{
    public partial class IndexBookings
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<BookingModel> BookingModels { get; set; }

        public List<TableModel> TableModels { get; set; }

        public AppModel Model { get; set; }

        public int DeleteId { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {

            //await base.OnInitializedAsync();
            await LoadBooking();
        }

        protected async Task LoadBooking()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Booking");
            if (res != null && res.succees)
            {
                BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
                TableModels = JsonConvert.DeserializeObject<List<TableModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
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
