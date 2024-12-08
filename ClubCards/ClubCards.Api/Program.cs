using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCards.Data.Repositories;
using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IRepository<BuyingEntity>, BuyingRepository>();
builder.Services.AddScoped<IRepository<CardEntity>, CardRepository>();
builder.Services.AddScoped<IRepository<CustomerEntity>, CustomerRepository>();
builder.Services.AddScoped<IRepository<PurchaseCenterEntity>, PurchaseCenterRepository>();
builder.Services.AddScoped<IRepository<StoreEntity>, StoreRepository>();

builder.Services.AddScoped<IBuyingService, BuyingService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPurchaseCenterService, PurchaseCenterService>();
builder.Services.AddScoped<IStoreService, StoreService>();

//builder.Services.AddSingleton<DataContext>();
builder.Services.AddDbContext<DataContext>(o =>
        o.UseSqlServer("Data Source=DESKTOP-SSNMLFD;Initial Catalog=ClubCards; Integrated Security=true;"));
 //"User ID=Michal;Password=1234");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
