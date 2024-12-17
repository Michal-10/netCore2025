
using Newtonsoft.Json;

using ClubCardsProject.Entities;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Channels;
using System.Diagnostics;

namespace ClubCardsProject.Data
{
    public class DataContext : DbContext
    {
        public DbSet<BuyingEntity> BuyingsList { get; set; }
        public DbSet<CardEntity> CardsList { get; set; }
        public DbSet<CustomerEntity> CustomersList { get; set; }
        public DbSet<PurchaseCenterEntity> PurchaseCentersList { get; set; }
        public DbSet<StoreEntity> StoresList { get; set; }

        //public DataContext()
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-SSNMLFD\\mssqllocaldb;database=ClubCards");
        //}
        //public DataContext(DbContextOptions<DataContext> option) : base(option)
        //{
        //    //OptionsBuilder.logTo(m=>Console.WriteLine(m));
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SSNMLFD;Initial Catalog=ClubCards; Integrated Security=true;");
            optionsBuilder.LogTo(m => Debug.WriteLine(m));
        }
    }
}
