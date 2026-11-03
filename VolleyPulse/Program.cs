using DAL.Repo;
using Logic;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
});

//Dependency Injection

//Logic
builder.Services.AddScoped<IEventLogic, EventLogic>();
builder.Services.AddScoped<IAttendanceLogic, AttendanceLogic>();
builder.Services.AddScoped<ITeamLogic, TeamLogic>();
builder.Services.AddScoped<ILoginLogic, LoginLogic>();

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

builder.Services.AddScoped<ITeamRepository>(provider =>
{
    string connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

    return new TeamRepository(connectionString);
});

builder.Services.AddScoped<ILoginRepository>(provider =>
{
    string connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

    return new LoginRepository(connectionString);
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

app.UseSession();

app.Run();
