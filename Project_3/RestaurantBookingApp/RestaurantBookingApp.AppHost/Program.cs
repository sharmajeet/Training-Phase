var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.RestaurantBookingApp_ApiService>("apiservice");

builder.AddProject<Projects.RestaurantBookingApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();