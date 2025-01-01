using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        // Pagination properties
        protected PaginationModel Pagination { get; set; } = new();
        protected int CurrentPage { get; set; } = 1;
        protected int PageSize { get; set; } = 7;

        // Dependency Injection
        [Inject]
        public ApiClient ApiClient { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        // Models
        public List<TableModel> tableModels { get; set; } = new(); // Original table data
        private List<TableModel> filteredTables = new(); // Filtered table data
        private int filterCapacity;

        public TableModel Tables { get; set; } = new TableModel { TableType = string.Empty };
        public BookingModel bookingModels { get; set; } = new BookingModel { CustomerName = string.Empty };
        public List<BookingModel> BookingModels { get; set; }

        // Modal properties
        public AppModel Model { get; set; }
        public PopUp BModel { get; set; }
        public int BookingId { get; set; }
        public int DeleteId { get; set; }

        // Initialization
        protected override async Task OnInitializedAsync()
        {
            await LoadTable(CurrentPage);
            filteredTables = tableModels; // Initialize filtered data with all tables
        }

        // Apply filter logic
        private void ApplyFilter()
        {
            if (filterCapacity > 0)
            {
                filteredTables = tableModels.Where(t => t.Capacity >= filterCapacity).ToList();
            }
            else
            {
                filteredTables = tableModels;
            }
            StateHasChanged();
        }

        // Load table data from API
        protected async Task LoadTable(int page)
        {
            try
            {
                CurrentPage = page;
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Table?page={page}&pageSize={PageSize}");

                if (res != null && res.succees)
                {
                    var data = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());
                    tableModels = data.Tables;
                    Pagination = data.Pagination;
                    filteredTables = tableModels; // Reset filtered data
                }
                else
                {
                    ToastService.ShowError("Failed to load tables.");
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError($"An error occurred while loading the tables: {ex.Message}");
            }
            StateHasChanged();
        }

        // Handle table deletion
        protected async Task HandleDelete()
        {
            try
            {
                var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Table/{DeleteId}");

                if (res != null && res.succees)
                {
                    ToastService.ShowSuccess("Table deleted successfully.");
                    await LoadTable(CurrentPage);
                    Model.Close();
                }
                else
                {
                    ToastService.ShowError("Failed to delete the table.");
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError($"An error occurred while deleting the table: {ex.Message}");
            }
        }
        //AllBookings
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

        // Load booking details based on Id
        protected async Task LoadBookingDetails(int Id)
        {
            try
            {
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Booking/{Id}");
                if (res != null && res.succees)
                {
                    bookingModels = JsonConvert.DeserializeObject<BookingModel>(res.Data.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An exception occurred while loading booking details.");
                Console.WriteLine(ex.Message);
            }
        }
        // Handle table booking
        protected async Task HandleBooking(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>($"/api/Booking/{Id}", bookingModels);

                    if (res != null && res.succees)
                    {
                        ToastService.ShowSuccess("Table booked successfully.");
                        await LoadTable(CurrentPage);
                        BModel.Close();
                    }
                    else
                    {
                        ToastService.ShowError("Failed to book the table.");
                    }
                }
                else
                {
                    ToastService.ShowError("Invalid table ID.");
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError($"An error occurred while booking the table: {ex.Message}");
            }
        }

        // Pagination model

        //protected async Task HandleBooking(int Id)
        //{
        //    try
        //    {
        //        if (Id != 0)
        //        {
        //            // Fetch all bookings for the table
        //            var existingBookingsRes = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Booking/{Id}");

        //            // Check if the response is valid and contains data
        //            if (existingBookingsRes != null && existingBookingsRes.firstOrDefault())
        //            {
        //                // Check for booking conflicts
        //                bool hasConflict = existingBookingsRes.Any(existing =>
        //                {
        //                    if (DateTime.TryParse(existing.TimeFrom, out DateTime existingStart) &&
        //                        DateTime.TryParse(existing.TimeTo, out DateTime existingEnd) &&
        //                        DateTime.TryParse(bookingModels.TimeFrom, out DateTime newStart) &&
        //                        DateTime.TryParse(bookingModels.TimeTo, out DateTime newEnd))
        //                    {
        //                        // Conflict occurs if the new booking time overlaps with an existing booking
        //                        return newStart < existingEnd && newEnd > existingStart;
        //                    }
        //                    return false;
        //                });

        //                if (hasConflict)
        //                {
        //                    ToastService.ShowError("The selected booking time conflicts with an existing booking.");
        //                    return; // Exit the method as there's a conflict
        //                }
        //            }
        //            else
        //            {
        //                // No existing bookings, proceed to create the booking
        //                var createRes = await ApiClient.PostAsync<BaseResponseModel, BookingModel>("/api/Booking/Create", bookingModels);

        //                if (createRes != null && createRes.succees)
        //                {
        //                    ToastService.ShowSuccess("Table booked successfully.");
        //                    await LoadTable(CurrentPage); // Reload table information
        //                    BModel.Close(); // Close the booking modal
        //                }
        //                else
        //                {
        //                    ToastService.ShowError("Failed to book the table.");
        //                }

        //                return; // Exit after creating the booking
        //            }

        //            // Proceed with booking if no conflict (whether new or existing booking)
        //            var finalRes = await ApiClient.PostAsync<BaseResponseModel, BookingModel>($"/api/Booking/{Id}", bookingModels);

        //            if (finalRes != null && finalRes.succees)
        //            {
        //                ToastService.ShowSuccess("Table booked successfully.");
        //                await LoadTable(CurrentPage);
        //                BModel.Close();
        //            }
        //            else
        //            {
        //                ToastService.ShowError("Failed to book the table.");
        //            }
        //        }
        //        else
        //        {
        //            ToastService.ShowError("Invalid table ID.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ToastService.ShowError($"An error occurred while booking the table: {ex.Message}");
        //    }
        //}

        //protected async Task HandleBooking(int Id)
        //{
        //    try
        //    {
        //        if (Id != 0)
        //        {
        //            // Fetch all bookings for the table
        //            var response = await ApiClient.GetFromJsonAsync<List<BookingModel>>($"/api/Booking/{Id}");

        //            // Check if the request was successful
        //            if (response != null)
        //            {
        //                // If no existing bookings found, directly create the booking
        //                if (!response.Any())
        //                {
        //                    var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>("/api/Booking/Create", bookingModels);

        //                    if (res != null && res.succees)
        //                    {
        //                        ToastService.ShowSuccess("Table booked successfully.");
        //                        await LoadTable(CurrentPage);
        //                        BModel.Close();
        //                    }
        //                    else
        //                    {
        //                        ToastService.ShowError("Failed to book the table.");
        //                    }

        //                    return; // Exit after booking creation
        //                }

        //                // If there are existing bookings, check for conflicts
        //                bool isConflictFound = response.Any(existing =>
        //                {
        //                    if (DateTime.TryParse(existing.TimeFrom, out DateTime existingStart) &&
        //                        DateTime.TryParse(existing.TimeTo, out DateTime existingEnd) &&
        //                        DateTime.TryParse(bookingModels.TimeFrom, out DateTime newStart) &&
        //                        DateTime.TryParse(bookingModels.TimeTo, out DateTime newEnd))
        //                    {
        //                        return newStart < existingEnd && newEnd > existingStart;
        //                    }
        //                    return false;
        //                });

        //                // If a conflict is found, display an error and return
        //                if (isConflictFound)
        //                {
        //                    ToastService.ShowError("The selected booking time conflicts with an existing booking.");
        //                    return;
        //                }

        //                // If no conflict, proceed to create the booking
        //                var finalRes = await ApiClient.PostAsync<BaseResponseModel, BookingModel>($"/api/Booking/{Id}", bookingModels);

        //                if (finalRes != null && finalRes.succees)
        //                {
        //                    ToastService.ShowSuccess("Table booked successfully.");
        //                    await LoadTable(CurrentPage);
        //                    BModel.Close();
        //                }
        //                else
        //                {
        //                    ToastService.ShowError("Failed to book the table.");
        //                }
        //            }
        //            else
        //            {
        //                // If the response is null or empty, log the error
        //                Console.WriteLine($"Error: Response is null or empty.");
        //                ToastService.ShowError("Failed to fetch existing bookings.");
        //            }
        //        }
        //        else
        //        {
        //            ToastService.ShowError("Invalid table ID.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Catch any unhandled exceptions and show a generic error message
        //        ToastService.ShowError($"An error occurred while booking the table: {ex.Message}");
        //    }
        //}

        public class PaginationModel
        {
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
        }

        // Table response model
        public class TableResponseModel
        {
            public List<TableModel> Tables { get; set; }
            public PaginationModel Pagination { get; set; }
        }
    }
}
