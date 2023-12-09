using Microsoft.EntityFrameworkCore;
using SOA_CA2.contexts;
using SOA_CA2.models;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql;

//string connectionString = "server=localhost;user=username;password=Password123!;database=plant_database";
string connectionString = "server=localhost;user=username;password=Password123!;database=plant_database";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddDbContext<PlantDB>(options =>
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
});*/

var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

builder.Services.AddDbContext<PlantDB>(options =>
    options.UseSqlServer(connection));

builder.Services.AddDbContext<CustomerDB>(options =>
    options.UseSqlServer(connection));

builder.Services.AddDbContext<Customer_invoiceDB>(options =>
    options.UseSqlServer(connection));

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






app.UseSwagger();
app.UseSwaggerUI();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

   
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=Customers}/{action=Index}/{id?}");
});

app.Run();
