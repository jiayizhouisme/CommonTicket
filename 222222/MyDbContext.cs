﻿using _222222.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 通用订票.Core.Entity;

namespace _222222
{
    public  class MyDbContext : DbContext
    {
        public DbSet<Model.Order> Orders { get; set; }
        public DbSet<Model.Appointment> Appointments{ get; set; }
        public DbSet<Model.Ticket> Tickets { get; set; }
        public DbSet<Model.UserInfo> UserInfos { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = "Data Source=.;Initial Catalog=CommonTicket1;user id=sa;password=Aa123456;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
        
    }
}
