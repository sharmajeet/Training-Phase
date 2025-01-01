var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.RestaurantApp_ApiService>("apiservice");

builder.AddProject<Projects.RestaurantApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
