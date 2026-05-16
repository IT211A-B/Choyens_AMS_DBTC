using AMS_DBTC_Frontend.Service;
using AMS_DBTC_Frontend.Services;


// Create builder
var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IAttendanceService, AttendanceService>();

// REGISTER HTTP CLIENT
builder.Services.AddHttpClient();


// REGISTER ATTENDANCE SERVICE
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
// REGISTER ATTENDANCE SERVICE
builder.Services.AddScoped<IAttendanceService, AttendanceService>();

var app = builder.Build();
var app = builder.Build();

// Configure error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Enable HTTPS
app.UseHttpsRedirection();

// Enable CSS, JS, Images
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Default page route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run application
app.Run();