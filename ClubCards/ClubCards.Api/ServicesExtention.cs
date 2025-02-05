using ClubCards.Core;
using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCards.Data.Repositories;
using ClubCardsProject.Data;
using ClubCardsProject.Services;

namespace ClubCards.Api
{
    public static class servicesExtention
    {
        public static void addDependency(this IServiceCollection services)
        {
            // Add services to the container.
            /* ---------Repositories----------*/
            services.AddScoped<IRepositoryBuying, BuyingRepository>();
            services.AddScoped<IRepositoryCard, CardRepository>();
            services.AddScoped<IRepositoryCustomer, CustomerRepository>();
            services.AddScoped<IRepositoryPurchaseCenter, PurchaseCenterRepository>();
            services.AddScoped<IRepositoryStore, StoreRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

            /* ---------services----------*/
            services.AddScoped<IBuyingService, BuyingService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPurchaseCenterService, PurchaseCenterService>();
            services.AddScoped<IStoreService, StoreService>();

            /* ---------DataContext----------*/
            services.AddDbContext<DataContext>();




            /*----------AutoMapper-----------*/
            services.AddAutoMapper(typeof(MappingProfile));

            // services.AddDbContext<DataContext>(option =>
            //           option.UseSqlServer("Data Source=DESKTOP-SSNMLFD;Initial Catalog=ClubCards; Integrated Security=true;"));
            //"User ID=Michal;Password=1234");

            
            //הגדרה להתעלם מהפניה מעגלית.(קשרי גומלין
            // services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //    options.JsonSerializerOptions.WriteIndented = true;
            //});

        }
    }
}
