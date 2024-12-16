using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitForm1;
using VisitForm1._222222;
using VisitForm1._222222.Model;


namespace _222222
{
    public  class MyDbContext : DbContext
    {
        private string connectionString;
        public DbSet<Order> Orders { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Appointment> Appointments{ get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserInfos> UserInfos { get; set; }
        public DbSet<Model.Exhibition> Exhibitions { get; set; }
       
      
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
