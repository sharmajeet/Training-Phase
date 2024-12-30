
using System.Collections.Generic;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;
using RestaurantApp.Web.Components.BaseComponent;

namespace RestaurantApp.Web.Components.Pages.Tables
{
    public partial class IndexTables
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<TableModel> tableModels { get; set; }

        public AppModel Model { get; set; }

        public int DeleteId { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
            await base.OnInitializedAsync();
            await LoadTable();
        }

        protected async Task LoadTable()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Table");
            if (res != null && res.succees)
            {
                tableModels = JsonConvert.DeserializeObject<List<TableModel>>(res.Data.ToString());

            }
            await base.OnInitializedAsync();
        }

        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Table/{DeleteId}");
            if(res != null && res.succees)
            {
                ToastService.ShowSuccess("Table Deleted Successfully.");
                await LoadTable();
                Model.Close();
            }
        }
    }
}
