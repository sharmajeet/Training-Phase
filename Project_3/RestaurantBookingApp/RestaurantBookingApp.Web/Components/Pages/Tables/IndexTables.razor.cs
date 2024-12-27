using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RestaurantApp_Model.Entities;
using RestaurantApp_Model.Models;

namespace RestaurantBookingApp.Web.Components.Pages.Tables
{
    public partial class IndexTables
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<TableModal> TableModals { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Table");
            if(res != null  && res.Success)
            {
                TableModals = JsonConvert.DeserializeObject<List<TableModal>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}
