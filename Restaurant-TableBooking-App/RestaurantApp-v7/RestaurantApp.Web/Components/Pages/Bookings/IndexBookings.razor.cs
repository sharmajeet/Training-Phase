
using Blazored.Toast.Services;
using Newtonsoft.Json;
using Restaurant_Models.Entities;
using Restaurant_Models.Models;
using RestaurantApp.Web.Components.BaseComponent;
using RestaurantApp.Web;
using static RestaurantApp.Web.Components.Pages.Tables.IndexTables;


namespace RestaurantApp.Web.Components.Pages.Bookings
{
    public partial class IndexBookings
    {
        private int PageSize = 5;
        private int CurrentPage = 1;
        private List<BookingModel> PaginatedBookings => BookingModels?.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        private int TotalPages => (int)Math.Ceiling((double)(BookingModels?.Count ?? 0) / PageSize);
        private bool IsFirstPage => CurrentPage == 1;
        private bool IsLastPage => CurrentPage == TotalPages;
        public List<BookingModel> BookingModels { get; set; }
        public List<TableModel> TableModels { get; set; }
        public AppModel Model { get; set; }
        public int DeleteId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadTable();
            await LoadBooking();
        }

        protected async Task LoadBooking()
        {
            try
            {
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Booking");
                if (res != null && res.succees)
                {
                    BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
                }
                else
                {
                    ToastService.ShowError("Failed to load bookings.");
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError($"An error occurred while loading bookings: {ex.Message}");
            }
        }

        protected async Task LoadTable()
        {
            try
            {
                var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Table");
                if (res != null && res.succees)
                {
                    var tableResponse = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());
                    TableModels = tableResponse?.Tables;
                }
                else
                {
                    ToastService.ShowError("Failed to load tables.");
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError($"An error occurred while loading tables: {ex.Message}");
            }
        }

        protected async Task HandleDelete()
        {
            try
            {
                var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Booking/{DeleteId}");
                if (res != null && res.succees)
                {
                    ToastService.ShowSuccess("Booking deleted successfully.");
                    await LoadBooking();
                    Model.Close();
                }
                else
                {
                    ToastService.ShowError("Failed to delete booking.");
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowError($"An error occurred while deleting the booking: {ex.Message}");
            }
        }

        private void PreviousPage()
        {
            if (!IsFirstPage)
            {
                CurrentPage--;
            }
        }

        private void NextPage()
        {
            if (!IsLastPage)
            {
                CurrentPage++;
            }
        }
    }
}


//using System.Net.NetworkInformation;
//using System.Threading.Channels;
//using System;
//using Blazored.Toast.Services;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Routing;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Newtonsoft.Json;
//using Restaurant_Models.Entities;
//using Restaurant_Models.Models;
//using RestaurantApp.Web;
//using RestaurantApp.Web.Components.BaseComponent;
//using static RestaurantApp.Web.Components.Pages.Tables.IndexTables;

//namespace RestaurantApp.Web.Components.Pages.Bookings
//{
//    public partial class IndexBookings
//    {

//        private int PageSize = 5;
//        private int CurrentPage = 1;
//        private List<BookingModel> PaginatedBookings => BookingModels?.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
//        private int TotalPages => (int)Math.Ceiling((double)(BookingModels?.Count ?? 0) / PageSize);
//        private bool IsFirstPage => CurrentPage == 1;
//        private bool IsLastPage => CurrentPage == TotalPages;
//        [Inject]
//        public ApiClient ApiClient { get; set; }
//        public List<BookingModel> BookingModels { get; set; }

//        public List<TableModel> TableModels { get; set; }
//        public List<TableModel> Tables { get; set; }

//        public AppModel Model { get; set; }

//        public int DeleteId { get; set; }
//        [Inject]
//        private IToastService ToastService { get; set; }
//        protected override async Task OnInitializedAsync()
//        {

//            await base.OnInitializedAsync();
//            await LoadTable();
//            await LoadBooking();

//        }
//        //protected async Task LoadBooking(int page)
//        //{
//        //    var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Booking");
//        //    if (res != null && res.succees)
//        //    {
//        //        BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
//        //        //TableModels = JsonConvert.DeserializeObject<List<TableModel>>(res.Data.ToString());
//        //    }
//        //    await base.OnInitializedAsync();
//        //}


//        //with pagination load booking


//        protected async Task LoadBooking()
//        {
//            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Booking");
//            if (res != null && res.succees)
//            {
//                BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
//            }
//        }

//        protected async Task LoadTable()
//        {
//            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Table");
//            if (res != null && res.succees)
//            {
//                var tableResponse = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());
//                TableModels = tableResponse?.Tables;
//            }
//        }
//        //protected async Task LoadBooking(int page)
//        //{
//        //    try
//        //    {
//        //        // Set the current page
//        //        CurrentPage = page;

//        //        // Call the API to fetch the data for the requested page
//        //        var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Booking?page={CurrentPage}&pageSize={PageSize}");

//        //        if (res != null && res.succees)
//        //        {
//        //            // Deserialize the response to a list of bookings
//        //            BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
//        //        }
//        //        else
//        //        {
//        //            ToastService.ShowError("Failed to load bookings.");
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ToastService.ShowError($"An error occurred while loading bookings: {ex.Message}");
//        //    }
//        //}



//        ////method for table 
//        //protected async Task LoadTable(int page)
//        //{
//        //    try
//        //    {
//        //        // Update the current page number
//        //        CurrentPage = page;

//        //        // Call the API to fetch the data for the requested page
//        //        var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Table?page={page}&pageSize={PageSize}");
//        //        Console.WriteLine(JsonConvert.SerializeObject(res.Data));

//        //        if (res != null && res.succees)
//        //        {
//        //            // Deserialize the response to a structured model
//        //            var data = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());

//        //            // Update the table data and pagination info
//        //            TableModels = data.Tables;
//        //            Pagination = data.Pagination;
//        //        }
//        //        else
//        //        {
//        //            ToastService.ShowError("Failed to load tables.");
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ToastService.ShowError("An error occurred while loading the tables.");
//        //    }

//        //    // Trigger a re-render of the component after data update
//        //    StateHasChanged();
//        //}

//        //with pagination- load table
//        //protected async Task LoadTable(int page)
//        //{
//        //    try
//        //    {
//        //        // Update the current page number
//        //        CurrentPage = page;

//        //        // Call the API to fetch the data for the requested page
//        //        var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/Table?page={CurrentPage}&pageSize={PageSize}");
//        //        Console.WriteLine(JsonConvert.SerializeObject(res.Data));

//        //        if (res != null && res.succees)
//        //        {
//        //            // Deserialize the response to a structured model
//        //            var data = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());

//        //            // Update the table data and pagination info
//        //            TableModels = data.Tables;
//        //            Pagination = data.Pagination;
//        //        }
//        //        else
//        //        {
//        //            ToastService.ShowError("Failed to load tables.");
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ToastService.ShowError("An error occurred while loading the tables.");
//        //    }

//        //    // Trigger a re-render of the component after data update
//        //    StateHasChanged();
//        //}



//        protected async Task HandleDelete()
//        {
//            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Booking/{DeleteId}");
//            if (res != null && res.succees)
//            {
//                ToastService.ShowSuccess("Booking Deleted Successfully.");
//                await LoadBooking();
//                Model.Close();
//            }
//        }

//        private void PreviousPage()
//        {
//            if (!IsFirstPage)
//            {
//                CurrentPage--;
//            }
//        }

//        private void NextPage()
//        {
//            if (!IsLastPage)
//            {
//                CurrentPage++;
//            }
//        }



//    }
//}



//////
////@page "/booking"
////@using Newtonsoft.Json;
////@using Restaurant_Models.Entities;
////@using Restaurant_Models.Models;
////@using static RestaurantApp.Web.Components.Pages.Tables.IndexTables;


////< p class= "text-center text-primary shadow-lg p-2 mb-2 bg-light-subtle rounded fs-1"
////   style = "font-family: 'Arial, sans-serif'; font-weight: bold; letter-spacing: 1px;" >
////    List Of All Bookings
////</p>
 
////@if (BookingModels == null)
////{
////<p>Loading...</p>
////}
////else
////{
////< a class= "btn btn-primary float-end" href = "/booking/create" > Create </ a >
////< table class= "table table-striped" >
////< thead >
////< tr >
////< th > Table ID </ th >
////< th > Table Property's'</th>
////<th>Customer Name</th>
////<th>Contact Number</th>
////<th>Date</th>
////<th>Time From</th>
////<th>Time To</th>
////<th>Action</th>
////</tr>
////</thead>
////<tbody>
////            @foreach (var booking in PaginatedBookings)
////            {
////              <tr>
//                //<td>@booking.TableId</td>
//                //<td>
////                        @if (TableModels != null)
////                        {
////                            var table = TableModels.FirstOrDefault(t => t.Id == booking.TableId);
////if (table != null)
////{
////< div >
////< span > Table Tag: @table.TableTag </ span >< br />
////< span > Capacity: @table.Capacity </ span >
////</ div >
////                            }
////else
////{
////< span > No table found</ span >
////                            }
////                        }
////</ td >
////< td > @booking.CustomerName </ td >
////< td > @booking.CustomerPhone </ td >
////< td > @booking.BookingDate.ToString("dd-MM-yyyy") </ td >
////< td > @DateTime.Parse(booking.TimeFrom).ToString("HH:mm") </ td >
////< td > @DateTime.Parse(booking.TimeTo).ToString("HH:mm") </ td >
////< td >
////< a class= "btn btn-secondary" href = "/booking/update/@booking.TableId" > Update </ a >
////< button class= "btn btn-danger" @onclick = "() => { DeleteId = booking.TableId; Model.Open(); }" > Delete </ button >
////</ td >
////</ tr >
////            }
////</ tbody >
////</ table >


////    < div class= "d-flex justify-content-between mt-3" >
////< button class= "btn btn-primary" @onclick = "PreviousPage" disabled = "@IsFirstPage" > Previous </ button >
////< span > Page @CurrentPage of @TotalPages</span>
////<button class= "btn btn-primary" @onclick = "NextPage" disabled = "@IsLastPage" > Next </ button >
////</ div >
////}


////< AppModel @ref = "Model" >
////< Title > Notification </ Title >
////< Body >
////        Do you sure want to Delete this booking?
////</Body>
////<Footer>
////<button type="button" class= "btn btn-primary" style = "width:80px" @onclick = "HandleDelete" > Yes </ button >
////< button type = "button" class= "btn btn-secondary" style = "width:80px" @onclick = "() => Model.Close()" > Cancel </ button >
////</ Footer >
////</ AppModel >

////@code {
////    [Inject]
////    public ApiClient ApiClient { get; set; }
////    public List<BookingModel> BookingModels { get; set; }
////public List<TableModel> TableModels { get; set; }
////public AppModel Model { get; set; }
////public int DeleteId { get; set; }
////[Inject]
////private IToastService ToastService { get; set; }

////private int PageSize = 5;
////private int CurrentPage = 1;
////private List<BookingModel> PaginatedBookings => BookingModels?.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
////private int TotalPages => (int)Math.Ceiling((double)(BookingModels?.Count ?? 0) / PageSize);
////private bool IsFirstPage => CurrentPage == 1;
////private bool IsLastPage => CurrentPage == TotalPages;

////protected override async Task OnInitializedAsync()
////{
////    await LoadTable();
////    await LoadBooking();
////}

////protected async Task LoadBooking()
////{
////    var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Booking");
////    if (res != null && res.succees)
////    {
////        BookingModels = JsonConvert.DeserializeObject<List<BookingModel>>(res.Data.ToString());
////    }
////}

////protected async Task LoadTable()
////{
////    var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Table");
////    if (res != null && res.succees)
////    {
////        var tableResponse = JsonConvert.DeserializeObject<TableResponseModel>(res.Data.ToString());
////        TableModels = tableResponse?.Tables;
////    }
////}

////protected async Task HandleDelete()
////{
////    var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Booking/{DeleteId}");
////    if (res != null && res.succees)
////    {
////        ToastService.ShowSuccess("Booking Deleted Successfully.");
////        await LoadBooking();
////        Model.Close();
////    }
////}

////private void PreviousPage()
////{
////    if (!IsFirstPage)
////    {
////        CurrentPage--;
////    }
////}

////private void NextPage()
////{
////    if (!IsLastPage)
////    {
////        CurrentPage++;
////    }
////}
 
 
////}
//////