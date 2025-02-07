﻿using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;

namespace RestaurantApp.Web.Components.Pages.Tables
{
    public partial class CreateTables
    {
        public TableModel Model { get; set; } = new ();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        // Handle table type change and show "Other" input field if selected

        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, TableModel>("/api/Table", Model);
            if (res != null && res.succees)
            {
                ToastService.ShowSuccess("Table Created Successfully.");
                NavigationManager.NavigateTo("/table");
            }
        }
    }
}
