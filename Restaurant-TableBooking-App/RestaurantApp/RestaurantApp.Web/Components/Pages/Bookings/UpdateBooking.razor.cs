using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;

namespace RestaurantApp.Web.Components.Pages.Bookings
{
    public partial class UpdateBooking : ComponentBase
    {

        [Parameter]
        public int Id { get; set; }
        public BookingModel Model { get; set; } = new BookingModel { CustomerName = string.Empty };

        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        IToastService ToastService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Booking/{Id}");
            if (res != null && res.succees)
            {
                Model = JsonConvert.DeserializeObject<BookingModel>(res.Data.ToString());
            }
        }

        public async Task Submit()
        {
            //call the put request
            var res = await ApiClient.PutAsync<BaseResponseModel, BookingModel>($"/api/Booking/{Id}", Model);

            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Booking Updated Successfully.");
                NavigationManager.NavigateTo("/table");

            }
        }

        public async Task cancelClick()
        {
            NavigationManager.NavigateTo("/booking");
        }
    }
}
