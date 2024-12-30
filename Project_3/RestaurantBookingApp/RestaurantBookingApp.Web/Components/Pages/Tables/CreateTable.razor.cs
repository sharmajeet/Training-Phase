using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using RestaurantApp_Model.Entities;
using RestaurantApp_Model.Models;

namespace RestaurantBookingApp.Web.Components.Pages.Tables
{
    public partial class CreateTable
    {
        public TableModal Modal { get; set; }
        [Inject]
        private ApiClient ApiClient { get; set; }

        private IToastService ToastService { get; set; }

        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, TableModal>("/api/Table", Modal);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Table Created Successfully");
            }
            else
            {
                ToastService.ShowSuccess("Error Creating Table");
            }
        }
    }
}
