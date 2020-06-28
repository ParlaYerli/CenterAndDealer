using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=WISGNURUN113\SQLEXPRESS; Database=Users; Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
               new Role() { Id = 1, Name = "CallCenter", CreatedDate = DateTime.Now, CreatedBy = 2 },
               new Role() { Id = 2, Name = "Dealer", CreatedDate = DateTime.Now, CreatedBy = 2 }    );

            modelBuilder.Entity<User>().HasData(
               new User()
               {
                   Id = 1,
                   CreatedBy = 1,
                   DealerId = 123123,
                   IsActive = true,
                   Password = "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195",//123123
                   RoleId = 1,
                   UpdatedDate = DateTime.Now,
                   CreatedDate = DateTime.Now,
                   UpdatedBy = 1,
                   FullName = "TestDealer",
                   DealerName = "Dealer1",
                   Address = "Test mah. Test sokak.",
                   City = "İstanbul",
                   Phone = "5552223355"
               },
               new User()
               {
                   Id = 2,
                   CreatedBy = 1,
                   DealerId = 123,
                   IsActive = true,
                   Password = "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195",//123123
                   RoleId = 2,
                   UpdatedDate = DateTime.Now,
                   CreatedDate = DateTime.Now,
                   UpdatedBy = 1,
                   FullName = "TestCallCenter",
                   DealerName = "Dealer2",
                   Address = "Test mah. Test sokak.",
                   City = "İstanbul",
                   Phone = "55522244555"
               });
            modelBuilder.Entity<LogType>().HasData(
               new LogType()
               {
                   Id = 1,
                   CreatedBy = 1,
                   CreatedDate = DateTime.Now,
                   Name = "Login"
               });
        }

    }
}
