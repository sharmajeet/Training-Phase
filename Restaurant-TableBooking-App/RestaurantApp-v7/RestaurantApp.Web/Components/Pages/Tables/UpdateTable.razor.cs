using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;

namespace RestaurantApp.Web.Components.Pages.Tables
{
    public partial class UpdateTable : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public TableModel Model { get; set; } = new TableModel { TableType = string.Empty };

        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        IToastService ToastService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Table/{Id}");
            if (res != null && res.succees)
            {
                Model = JsonConvert.DeserializeObject<TableModel>(res.Data.ToString());
            }
        }

        public async Task Submit()
        {
            //call the put request
            var res = await ApiClient.PutAsync<BaseResponseModel, TableModel>($"/api/Table/{Id}", Model);

            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Table Updated Successfully.");
                NavigationManager.NavigateTo("/table");

            }
        }

        public async Task cancelClick()
        {
            NavigationManager.NavigateTo("/table");
        }
    }
}