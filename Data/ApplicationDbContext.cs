using BarberShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            

        }

        public DbSet<HairCut> HairCuts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<HairCut>().HasData(
                    new HairCut
                    {
                        Id = 1,
                        Type = "Buzz Cut",
                        Barber = "Samuel",
                        Date = DateTime.Now

                    },
                     new HairCut
                     {
                         Id = 2,
                         Type = "Pompadur",
                         Barber = "Nir",
                         Date = DateTime.Now

                     }
                    );

        }


    }
}
