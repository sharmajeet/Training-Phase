using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;

namespace RestaurantApp.Web.Components.Pages.Bookings
{
    public partial class IndexBookings
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<BookingModel> BookingModels { get; set; }

        public List<TableModel> TableModels { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Booking");
            if (res != null && res.succees)
            {
                BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
                TableModels = JsonConvert.DeserializeObject<List<TableModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}
