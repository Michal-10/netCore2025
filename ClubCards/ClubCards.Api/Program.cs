using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCards.Data.Repositories;
using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* ---------Repositories----------*/
builder.Services.AddScoped<IRepositoryBuying, BuyingRepository>();
builder.Services.AddScoped<IRepositoryCard, CardRepository>();
builder.Services.AddScoped<IRepositoryCustomer , CustomerRepository>();
builder.Services.AddScoped<IRepositoryPurchaseCenter, PurchaseCenterRepository>();
builder.Services.AddScoped<IRepositoryStore, StoreRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

/* ---------Services----------*/
builder.Services.AddScoped<IBuyingService, BuyingService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IPurchaseCenterService, PurchaseCenterService>();
builder.Services.AddScoped<IStoreService, StoreService>();

/* ---------DataContext----------*/
builder.Services.AddDbContext<DataContext>();
//builder.Services.AddDbContext<DataContext>(option =>
//           option.UseSqlServer("Data Source=DESKTOP-SSNMLFD;Initial Catalog=ClubCards; Integrated Security=true;"));
//"User ID=Michal;Password=1234");


builder.Services.AddControllers();
//הגדרה להתעלם מהפניה מעגלית.(קשרי גומלין
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//    options.JsonSerializerOptions.WriteIndented = true;
//});

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
