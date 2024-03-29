﻿using AoW.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AoW.EntityFramework.Date
{
    public class AowDbContext : DbContext
    {
        public AowDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Staff> Staff { get; set; }        
        public DbSet<WorkWear> Workwear { get; set; }        
        public DbSet<ReceiptInfo> ReceiptInfo { get; set; }
        public DbSet<ExtraditionInfo> ExtraditionInfo { get; set; }
        public DbSet<Provider> Provider { get; set; }

    }
}
