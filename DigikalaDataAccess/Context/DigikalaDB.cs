using DigikalaDataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigikalaDataAccess.Context
{
    public class DigikalaDB : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserID = 1,
                UserName = "Admin",
                UserPassword = "admin",
                UserType = 0
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = X541U; Initial Catalog = DigikalaDB; Integrated Security = True");
        }
        public DbSet <User> Users { get; set; }
        public DbSet <Comment> Comments { get; set; }
        public DbSet <Product> Products { get; set; }
    }
}
