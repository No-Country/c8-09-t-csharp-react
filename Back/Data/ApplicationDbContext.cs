
using CohorteApi.Data.Seeds;
using CohorteApi.Data.Seeds.Events;
using CohorteApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CohorteApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);
            UsersSeed.GetData(modelBuilder);
            modelBuilder.Entity<Subscription>().HasData(SubscriptionsSeed.GetData());
            modelBuilder.Entity<Category>().HasData(CategoriesSeed.GetData());
            modelBuilder.Entity<Event>().HasData(EventsSeed.GetData());


        }
    }
}



