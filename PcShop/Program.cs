using Microsoft.EntityFrameworkCore;
using Npgsql;
using PcShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add enums in DataSource
var connectionString = builder.Configuration.GetConnectionString("PsqlConnection");
builder.Services.AddDbContext<PcshopContext>(options => options.UseNpgsql(
    connectionString,
    o => o
        .MapEnum<ProductStatus>("product_status")
        .MapEnum<OrderStatus>("order_status")
        .MapEnum<PaymentType>("payment_type")
        .MapEnum<UserRole>("user_role")
));

// Add services to the container.
builder.Services.AddRazorPages();


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
