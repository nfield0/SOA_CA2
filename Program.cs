using Microsoft.EntityFrameworkCore;
using SOA_CA2.contexts;
using SOA_CA2.models;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql;

string connectionString = "server=localhost;user=user;password=Password123!;database=plant_database";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PlantDB>(options =>
{
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddDbContext<CustomerDB>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddDbContext<Customer_invoiceDB>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


var app = builder.Build();

/*app.MapGet("/plants", async (PlantDB db) =>
    await db.Plant.ToListAsync());

app.MapGet("/customers", async (CustomerDB db) =>
    await db.Customer.ToListAsync());

app.MapGet("/customer_invoices", async (Customer_invoiceDB db) =>
    await db.Customer_invoice.ToListAsync());

app.MapPost("/plants", async (PlantDB db, Plant plant) =>
    await db.Plant.AddAsync(plant)
    );

*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
