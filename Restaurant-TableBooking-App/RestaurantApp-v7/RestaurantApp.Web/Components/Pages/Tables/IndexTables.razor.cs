﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;
using RestaurantApp.Web.Components.BaseComponent;
using System.Text.Json;

namespace RestaurantApp.Web.Components.Pages.Tables
{
    public partial class IndexTables
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }


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
        private void ClearFilter()
        {
            filterCapacity = 0;
            filteredTables = tableModels.ToList();
           
            CurrentPage = 1; // Reset to the first page
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

        //// Handle table booking
        //protected async Task HandleBooking(int Id)
        //{
        //    try
        //    {
        //        if (Id != 0)
        //        {
        //            var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>($"/api/Booking/{Id}", bookingModels);

        //            if (res != null && res.succees)
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

        //            if (response == null)
        //            {
        //                var res = await ApiClient.PostAsync<BaseResponseModel, BookingModel>("/api/Booking/Create", bookingModels);

        //                if (res != null && res.succees)
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
        //            bool isConflictFound = response.Any(existing =>
        //            {
        //                if (DateTime.TryParse(existing.TimeFrom, out DateTime existingStart) &&
        //                    DateTime.TryParse(existing.TimeTo, out DateTime existingEnd) &&
        //                    DateTime.TryParse(bookingModels.TimeFrom, out DateTime newStart) &&
        //                    DateTime.TryParse(bookingModels.TimeTo, out DateTime newEnd))
        //                {
        //                    return newStart < existingEnd && newEnd > existingStart;
        //                }
        //                return false;
        //            });

        //            // If a conflict is found, display an error and return
        //            if (isConflictFound)
        //            {
        //                ToastService.ShowError("The selected booking time conflicts with an existing booking.");
        //                return;
        //            }

        //            // If no conflict, proceed to create the booking
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
        //            // If the response is null or empty, log the error
        //            Console.WriteLine($"Error: Response is null or empty.");
        //            ToastService.ShowError("Failed to fetch existing bookings.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // Catch any unhandled exceptions and show a generic error message
        //        ToastService.ShowError($"An error occurred while booking the table: {ex.Message}");
        //    }
        //}

        // Define the generic method to fetch data
        // Define the generic method to fetch data

        public async Task<List<dynamic>> GetFromJsonAsListAsync<T>(string path)
        {
            try
            {
                // First, get the BaseResponseModel
                var baseResponse = await ApiClient.GetFromJsonAsync<BaseResponseModel>(path);
                if (baseResponse?.succees != true || baseResponse.Data == null)
                {
                    ToastService.ShowError("Failed to fetch booking data");
                    return new List<dynamic>();
                }

               //list banavsu
                try
                {
                    var bookings = JsonConvert.DeserializeObject<List<T>>(baseResponse.Data.ToString());
                    if (bookings != null)
                    {
                        return bookings.Select(item => new
                        {
                            Id = item.GetType().GetProperty("Id")?.GetValue(item),
                            TimeFrom = item.GetType().GetProperty("TimeFrom")?.GetValue(item)?.ToString(),
                            TimeTo = item.GetType().GetProperty("TimeTo")?.GetValue(item)?.ToString()
                        }).Cast<dynamic>().ToList();
                    }
                }
                catch
                {
                    // If list deserialization fails, try as single object
                    var booking = JsonConvert.DeserializeObject<T>(baseResponse.Data.ToString());
                    if (booking != null)
                    {
                        return new List<dynamic>
                        {
                            new
                            {
                                Id = booking.GetType().GetProperty("Id")?.GetValue(booking),
                                TimeFrom = booking.GetType().GetProperty("TimeFrom")?.GetValue(booking)?.ToString(),
                                TimeTo = booking.GetType().GetProperty("TimeTo")?.GetValue(booking)?.ToString()
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError($"Error processing booking data: {ex.Message}");
            }

            return new List<dynamic>();
        }


        private bool isBookingInProgress = false;
        protected async Task HandleBooking(int bookingId, string timeFrom, string timeTo)
        {
            if (isBookingInProgress)
                return;

            try
            {
                isBookingInProgress = true;

                // Check for valid booking ID
                if (bookingId == 0)
                {
                    ToastService.ShowError("Invalid booking ID.");
                    return;
                }

                // Basic validation for the booking model
                if (string.IsNullOrEmpty(bookingModels.CustomerName) ||
                    string.IsNullOrEmpty(bookingModels.CustomerPhone) ||
                     //bookingModels.BookingDate == default)
                     bookingModels.BookingDate < DateTime.Now.Date)
                {
                    ToastService.ShowError("Please Enter Valid Date.");
                    return;
                }

                // Fetch existing bookings
                var existingBookings = await GetFromJsonAsListAsync<dynamic>($"/api/Booking/{bookingId}");

                // If no existing bookings found, create a new booking directly
                if (existingBookings == null || !existingBookings.Any())
                {
                    // Set the booking details
                    bookingModels.TableId = bookingId;
                    bookingModels.TimeFrom = timeFrom;
                    bookingModels.TimeTo = timeTo;

                    // Create new booking
                    var createResponse = await ApiClient.PostAsync<BaseResponseModel, BookingModel>(
                        "/api/Booking/Create",
                        bookingModels
                    );

                    if (createResponse?.succees == true)
                    {

                        ToastService.ShowSuccess("Table booked successfully.");
                        await LoadTable(CurrentPage);
                        BModel.Close();
                    }
                    else
                    {
                        ToastService.ShowError("Failed to create booking.");
                    }
                    return;
                }

                // If there are existing bookings, check for conflicts
                bool isConflictFound = existingBookings.Any(existing =>
                {
                    var existingTimeFrom = existing.TimeFrom?.ToString();
                    var existingTimeTo = existing.TimeTo?.ToString();

                    if (string.IsNullOrEmpty(existingTimeFrom) ||
                        string.IsNullOrEmpty(existingTimeTo) ||
                        string.IsNullOrEmpty(timeFrom) ||
                        string.IsNullOrEmpty(timeTo))
                    {
                        return false;
                    }

                    try
                    {
                        // Convert time strings to DateTime for proper comparison
                        DateTime existingStart = DateTime.Parse(existingTimeFrom);
                        DateTime existingEnd = DateTime.Parse(existingTimeTo);
                        DateTime newStart = DateTime.Parse(timeFrom);
                        DateTime newEnd = DateTime.Parse(timeTo);

                        // Check if the new booking overlaps with existing booking
                        return (newStart < existingEnd && newEnd > existingStart);
                    }
                    catch (Exception)
                    {
                        // If there's any error parsing the times, assume no conflict
                        return false;
                    }
                });

                if (isConflictFound)
                {
                    ToastService.ShowError("The selected booking time conflicts with an existing booking.");
                    return;
                }

                // Create the booking if no conflicts
                bookingModels.TableId = bookingId;
                bookingModels.TimeFrom = timeFrom;
                bookingModels.TimeTo = timeTo;

                var createBookingResponse = await ApiClient.PostAsync<BaseResponseModel, BookingModel>(
                    "/api/Booking/Create",
                    bookingModels
                );

                if (createBookingResponse.isDuplicate = true)
                    {
                    ToastService.ShowError("There Is Time Conflict While Booking The Table.");
                    await LoadTable(CurrentPage);
                    BModel.Close();
                }
                else if (createBookingResponse?.succees == true)
                    {
                    ToastService.ShowSuccess("Table booked successfully.");
                    await LoadTable(CurrentPage);
                    BModel.Close();
                }
                else
                {
                    ToastService.ShowError("There Is Time Conflict While Booking The Table.");
                }

            }
            catch (Exception ex)
            {
                ToastService.ShowError($"An error occurred while booking the table: {ex.Message}");
            }
            finally
            {
                isBookingInProgress = false;
            }
        }

       
        /// <summary>
        /// ///////
        /// </summary>
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