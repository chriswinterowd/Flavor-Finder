using FlavorFinder.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container
builder.Services.AddHttpClient(); // Register HttpClient for API calls
builder.Services.AddTransient<SpoonacularService>(); // Register SpoonacularService
builder.Services.AddControllers(); // Register controllers

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Show detailed errors in development
}

app.UseHttpsRedirection();

app.MapControllers(); // Map controller endpoints

app.Run();
