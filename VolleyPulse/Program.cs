using DAL;
using DAL.Repo;
using Logic;
using Logic.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Dependency Injection

//Logic
builder.Services.AddScoped<IEventLogic, EventLogic>();
builder.Services.AddScoped<IAttendanceLogic, AttendanceLogic>();

//DAL
builder.Services.AddScoped<IEventRepository>(provider =>
{
    string connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

    return new EventRepository(connectionString);
});

builder.Services.AddScoped<IAttendanceRepository>(provider =>
{
    string connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

    return new AttendanceRepository(connectionString);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
